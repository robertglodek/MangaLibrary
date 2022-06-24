using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Manga;
using MangaLibrary.ApplicationServices.API.Domain.Models.Manga;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.CQRS.Commands.Generic;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Manga
{
    public class UpdateMangaRequestHandler : IRequestHandler<UpdateMangaRequest, UpdateMangaResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;

        public UpdateMangaRequestHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }
        public async Task<UpdateMangaResponse> Handle(UpdateMangaRequest request, CancellationToken cancellationToken)
        {

            var item = await _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.Manga>() { Id = request.Id, PropertiesToInclude = "Genres,Creators" });
            if (item == null)
                return new UpdateMangaResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Manga with id: {request.Id} doesn't exist") };
            if (request.DemographicId != item.DemographicId)
            {
                var demographicExists = await _queryExecutor.Execute(new ResourceExistsQuery<MangaLibrary.DataAccess.Entities.Demographic>() { Id = request.DemographicId });
                if (!demographicExists)
                    return new UpdateMangaResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Demographic with id: {request.DemographicId} doesn't exist") };
            }
            if (!Enumerable.SequenceEqual(request.GenresIds, item.Genres.Select(n => n.Id)))
            {
                var genres = await _queryExecutor.Execute(new GetResourcesForQuery<MangaLibrary.DataAccess.Entities.Genre>() { Ids = request.GenresIds });
                if (genres.Count() != request.GenresIds.Count())
                    return new UpdateMangaResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Some of provided genres don't exist") };
                item.Genres.RemoveAll(n => !request.GenresIds.Contains(n.Id));
                item.Genres.AddRange(genres.Where(n => request.GenresIds.Except(item.Genres.Select(n => n.Id)).Contains(n.Id)));

            }
            if (!Enumerable.SequenceEqual(request.CreatorsIds, item.Creators.Select(n => n.Id)))
            {
                var creators = await _queryExecutor.Execute(new GetResourcesForQuery<MangaLibrary.DataAccess.Entities.Creator>() { Ids = request.CreatorsIds });
                if (creators.Count() != request.CreatorsIds.Count())
                    return new UpdateMangaResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Some of provided creators don't exist") };
                item.Creators.RemoveAll(n => !request.CreatorsIds.Contains(n.Id));
                item.Creators.AddRange(creators.Where(n => request.CreatorsIds.Except(item.Creators.Select(n => n.Id)).Contains(n.Id)));
            }
            var command = new UpdateResourceCommand<MangaLibrary.DataAccess.Entities.Manga>() { Parameter = _mapper.Map(request, item) };
            var result = await _commandExecutor.Execute(command);
            return new UpdateMangaResponse() { Data = _mapper.Map<MangaDTO>(result) };

        }
    }
}
