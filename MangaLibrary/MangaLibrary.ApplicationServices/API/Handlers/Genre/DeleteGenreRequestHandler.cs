using MangaLibrary.ApplicationServices.API.Domain.Genre;
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

namespace MangaLibrary.ApplicationServices.API.Handlers.Genre
{
    public class DeleteGenreRequestHandler : IRequestHandler<DeleteGenreRequest, DeleteGenreResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public DeleteGenreRequestHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;

        }
        public async Task<DeleteGenreResponse> Handle(DeleteGenreRequest request, CancellationToken cancellationToken)
        {
            var item = await _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.Genre>() { Id = request.Id });
            if (item == null)
                return new DeleteGenreResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Genre with id: {request.Id} doesn't exist") };
            var command = new DeleteResourceCommand<MangaLibrary.DataAccess.Entities.Genre>() { Parameter = item };
            var result = await _commandExecutor.Execute(command);
            return new DeleteGenreResponse() { Data = result };
        }
    }
}
