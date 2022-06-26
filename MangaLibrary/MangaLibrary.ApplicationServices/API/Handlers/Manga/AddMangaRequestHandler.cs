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
    public class AddMangaRequestHandler : IRequestHandler<AddMangaRequest, AddMangaResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public AddMangaRequestHandler(ICommandExecutor executor, IMapper mapper,IQueryExecutor queryExecutor)
        {
            _commandExecutor = executor;
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }
        public async Task<AddMangaResponse> Handle(AddMangaRequest request, CancellationToken cancellationToken)
        {
            var demographicExists = await _queryExecutor.Execute(new ResourceExistsQuery<MangaLibrary.DataAccess.Entities.Demographic>() { Id = request.DemographicId });
            if(!demographicExists)
                return new AddMangaResponse() {  Error=new Domain.ErrorModel(ErrorType.NotFound, $"Demographic with id: {request.DemographicId} doesn't exist") };

            var item = _mapper.Map<MangaLibrary.DataAccess.Entities.Manga>(request);
            item.Genres = new List<MangaLibrary.DataAccess.Entities.Genre>();
            item.Characters = new List<MangaLibrary.DataAccess.Entities.Character>();
            item.Creators = new List<MangaLibrary.DataAccess.Entities.Creator>();

            if (!await CheckItemsToAdd(request.GenresIds, item.Genres))
                return new AddMangaResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Some of provided genres don't exist") };
            if (!await CheckItemsToAdd(request.CreatorsIds, item.Creators))
                return new AddMangaResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Some of provided creators don't exist") };
            if (!await CheckItemsToAdd(request.CharactersIds, item.Characters))
                return new AddMangaResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Some of provided characters don't exist") };
            var result = await _commandExecutor.Execute(new AddResourceCommand<MangaLibrary.DataAccess.Entities.Manga>() { Parameter = item });
            return new AddMangaResponse() { Data = _mapper.Map<MangaDTO>(result) };
        }

        private async Task<bool> CheckItemsToAdd<T>(IEnumerable<Guid> requestIds, List<T> sourceItems) where T : EntityBase
        {
            if (requestIds == null || requestIds.Count() == 0)
                return true;
            var queryItems = await _queryExecutor.Execute(new GetResourcesForQuery<T>() { Ids = requestIds });
            if (queryItems.Count() != requestIds.Count())
                return false;
            sourceItems.AddRange(queryItems);
            return true;
        }
    }
}
