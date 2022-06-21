using MangaLibrary.ApplicationServices.API.Domain.Manga;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
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
    public class DeleteMangaRequestHandler : IRequestHandler<DeleteMangaRequest, DeleteMangaResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;
        public DeleteMangaRequestHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }
        public async Task<DeleteMangaResponse> Handle(DeleteMangaRequest request, CancellationToken cancellationToken)
        {
            var item = await _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.Manga>() { Id = request.Id });
            if (item == null)
                return new DeleteMangaResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Manga with id: {request.Id} doesn't exist") };
            var command = new DeleteResourceCommand<MangaLibrary.DataAccess.Entities.Manga>() { Parameter = item };
            var result = await _commandExecutor.Execute(command);
            return new DeleteMangaResponse() { Data = result };
        }
    }
}
