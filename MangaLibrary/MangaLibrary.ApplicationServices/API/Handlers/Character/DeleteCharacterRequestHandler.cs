using MangaLibrary.ApplicationServices.API.Domain.Character;
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

namespace MangaLibrary.ApplicationServices.API.Handlers.Character
{

    public class DeleteCharacterRequestHandler : IRequestHandler<DeleteCharacterRequest, DeleteCharacterResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public DeleteCharacterRequestHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;

        }
        public async Task<DeleteCharacterResponse> Handle(DeleteCharacterRequest request, CancellationToken cancellationToken)
        {
            var item = await _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.Character>() { Id = request.Id });
            if (item == null)
                return new DeleteCharacterResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Character with id: {request.Id} doesn't exist") };
            var command = new DeleteResourceCommand<MangaLibrary.DataAccess.Entities.Character>() { Parameter = item };
            var result = await _commandExecutor.Execute(command);
            return new DeleteCharacterResponse() { Data = result };
        }
    }
}
