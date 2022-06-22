using MangaLibrary.ApplicationServices.API.Domain.Creator;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.CQRS.Commands.Generic;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.Creator;
using MangaLibrary.DataAccess.CQRS.Queries.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Creator
{
    public class DeleteCreatorRequestHandler:IRequestHandler<DeleteCreatorRequest, DeleteCreatorResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public DeleteCreatorRequestHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;

        }
        public async Task<DeleteCreatorResponse> Handle(DeleteCreatorRequest request, CancellationToken cancellationToken)
        {
            var item = await  _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.Creator>() { Id = request.Id });
            if(item == null)
                return new DeleteCreatorResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Creator with id: {request.Id} doesn't exist") };
            var command = new DeleteResourceCommand<MangaLibrary.DataAccess.Entities.Creator>() { Parameter = item };
            var result = await _commandExecutor.Execute(command);
            return new DeleteCreatorResponse() { Data = result };
        }
    }
}
