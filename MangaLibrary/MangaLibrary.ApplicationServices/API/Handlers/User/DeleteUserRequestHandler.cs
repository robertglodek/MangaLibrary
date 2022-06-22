using MangaLibrary.ApplicationServices.API.Domain.User;
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

namespace MangaLibrary.ApplicationServices.API.Handlers.User
{
    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public DeleteUserRequestHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;

        }
        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var item = await _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.User>() { Id = request.Id });
            if (item == null)
                return new DeleteUserResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"User with id: {request.Id} doesn't exist") };
            var command = new DeleteResourceCommand<MangaLibrary.DataAccess.Entities.User>() { Parameter = item };
            var result = await _commandExecutor.Execute(command);
            return new DeleteUserResponse() { Data = result };
        }
    }
}
