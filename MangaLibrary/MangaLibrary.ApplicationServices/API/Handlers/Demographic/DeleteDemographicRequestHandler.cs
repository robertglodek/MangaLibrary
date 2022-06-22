using MangaLibrary.ApplicationServices.API.Domain.Demographic;
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

namespace MangaLibrary.ApplicationServices.API.Handlers.Demographic
{

    public class DeleteDemographicRequestHandler : IRequestHandler<DeleteDemographicRequest, DeleteDemographicResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public DeleteDemographicRequestHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;

        }
        public async Task<DeleteDemographicResponse> Handle(DeleteDemographicRequest request, CancellationToken cancellationToken)
        {
            var item = await _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.Demographic>() { Id = request.Id });
            if (item == null)
                return new DeleteDemographicResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Demographic with id: {request.Id} doesn't exist") };
            var command = new DeleteResourceCommand<MangaLibrary.DataAccess.Entities.Demographic>() { Parameter = item };
            var result = await _commandExecutor.Execute(command);
            return new DeleteDemographicResponse() { Data = result };
        }
    }
}
