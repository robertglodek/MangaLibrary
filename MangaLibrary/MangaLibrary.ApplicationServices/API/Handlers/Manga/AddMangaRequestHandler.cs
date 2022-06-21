using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Manga;
using MangaLibrary.ApplicationServices.API.Domain.Models.Manga;
using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.CQRS.Commands.Generic;
using MangaLibrary.DataAccess.CQRS.Commands.Manga;
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
            var item = _mapper.Map<MangaLibrary.DataAccess.Entities.Manga>(request);
            var genres= await _queryExecutor.Execute(new GetResourcesForQuery<MangaLibrary.DataAccess.Entities.Genre>() { Ids=request.GenresIds});
            var creators= await _queryExecutor.Execute(new GetResourcesForQuery<MangaLibrary.DataAccess.Entities.Creator>() { Ids=request.CreatorsIds});
            item.Genres = genres;
            item.Creators = creators;
            var result = await _commandExecutor.Execute(new AddResourceCommand<MangaLibrary.DataAccess.Entities.Manga>() { Parameter = item });
            return new AddMangaResponse() { Data = _mapper.Map<MangaDTO>(result) };
        }
    }
}
