using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Manga;
using MangaLibrary.ApplicationServices.API.Domain.Models.Manga;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.CQRS.Commands.Generic;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.Generic;
using MangaLibrary.DataAccess.Entities;
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

            var item = await _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.Manga>() { Id = request.Id, PropertiesToInclude = "Genres,Creators,Characters" });
            if (item == null)
                return new UpdateMangaResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Manga with id: {request.Id} doesn't exist") };
            if (request.DemographicId != item.DemographicId)
            {
                var demographicExists = await _queryExecutor.Execute(new ResourceExistsQuery<MangaLibrary.DataAccess.Entities.Demographic>() { Id = request.DemographicId });
                if (!demographicExists)
                    return new UpdateMangaResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Demographic with id: {request.DemographicId} doesn't exist") };
            }

            if(! await CheckItemsToUpdate(request.GenresIds,item.Genres))
                return new UpdateMangaResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Some of provided genres don't exist") };
            if (!await CheckItemsToUpdate(request.CreatorsIds, item.Creators))
                return new UpdateMangaResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Some of provided creators don't exist") };
            if (!await CheckItemsToUpdate(request.CharactersIds, item.Characters))
                return new UpdateMangaResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Some of provided characters don't exist") };

            var command = new UpdateResourceCommand<MangaLibrary.DataAccess.Entities.Manga>() { Parameter = _mapper.Map(request, item) };
            var result = await _commandExecutor.Execute(command);
            return new UpdateMangaResponse() { Data = _mapper.Map<MangaDTO>(result) };

        }
        private async Task<bool> CheckItemsToUpdate<T>(IEnumerable<Guid> requestIds,List<T> sourceItems) where T: EntityBase
        {
            if (requestIds == null || requestIds.Count() == 0)
                return true;
            if (!Enumerable.SequenceEqual(requestIds, sourceItems.Select(n => n.Id)))
                return true;
            var queryItems = await _queryExecutor.Execute(new GetResourcesForQuery<T>() { Ids = requestIds });
            if (queryItems.Count() != requestIds.Count())
                return false;
            sourceItems.RemoveAll(n => !requestIds.Contains(n.Id));
            sourceItems.AddRange(queryItems.Where(n => requestIds.Except(sourceItems.Select(n => n.Id)).Contains(n.Id)));
            return true;  
        }
    }

   
    
}
