using MangaLibrary.ApplicationServices.API.Domain.Volume;
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

namespace MangaLibrary.ApplicationServices.API.Handlers.Volume
{
    public class DeleteVolumeRequestHandler : IRequestHandler<DeleteVolumeRequest, DeleteVolumeResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;
        public DeleteVolumeRequestHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }
        public async Task<DeleteVolumeResponse> Handle(DeleteVolumeRequest request, CancellationToken cancellationToken)
        {
            var item = await _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.Volume>() { Id = request.Id });
            if (item == null)
                return new DeleteVolumeResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Volume with id: {request.Id} doesn't exist") };
            var command = new DeleteResourceCommand<MangaLibrary.DataAccess.Entities.Volume>() { Parameter = item };
            var result = await _commandExecutor.Execute(command);
            return new DeleteVolumeResponse() { Data = result };
        }
    }
}
