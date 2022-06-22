using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Creator;
using MangaLibrary.ApplicationServices.API.Domain.Models.Creator;
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

namespace MangaLibrary.ApplicationServices.API.Handlers.Creator
{

    public class UpdateCreatorRequestHandler : IRequestHandler<UpdateCreatorRequest, UpdateCreatorResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;

        public UpdateCreatorRequestHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }
        public async Task<UpdateCreatorResponse> Handle(UpdateCreatorRequest request, CancellationToken cancellationToken)
        {
            var item = await _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.Creator>() { Id = request.Id });
            if (item == null)
                return new UpdateCreatorResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound,$"Creator with id: {request.Id} doesn't exist")};
            var command = new UpdateResourceCommand<MangaLibrary.DataAccess.Entities.Creator>() { Parameter = _mapper.Map(request, item) };
            var result = await _commandExecutor.Execute(command);
            return new UpdateCreatorResponse() { Data = _mapper.Map<CreatorDTO>(result) };
        }
    }
}
