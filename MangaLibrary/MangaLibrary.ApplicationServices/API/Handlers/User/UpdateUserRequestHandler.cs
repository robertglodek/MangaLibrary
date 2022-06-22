using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models.User;
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
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;

        public UpdateUserRequestHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
        }
        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var item = await _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.User>() { Id = request.Id });
            if (item == null)
                return new UpdateUserResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"User with id: {request.Id} doesn't exist") };

            var command = new UpdateResourceCommand<MangaLibrary.DataAccess.Entities.User>() { Parameter = _mapper.Map(request, item) };
            var result = await _commandExecutor.Execute(command);
            return new UpdateUserResponse() { Data = _mapper.Map<UserDTO>(result) };

        }
    }
}
