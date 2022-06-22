using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models.User;
using MangaLibrary.ApplicationServices.API.Domain.User;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.CQRS.Commands.Generic;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.Generic;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.User
{
    public class RegisterUserRequestHandler : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<DataAccess.Entities.User> _passwordHasher;
        private readonly IQueryExecutor _queryExecutor;

        public RegisterUserRequestHandler(ICommandExecutor commandExecutor, IMapper mapper,
            IPasswordHasher<MangaLibrary.DataAccess.Entities.User> passwordHasher,IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _queryExecutor = queryExecutor;
        }
        public async Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var role = await _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.Role>());
            if (role == null)
                return new RegisterUserResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Role with id: {request.RoleId} doesn't exist") };
            var user = _mapper.Map<MangaLibrary.DataAccess.Entities.User>(request);
            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);
            var command = new AddResourceCommand<MangaLibrary.DataAccess.Entities.User>() { Parameter = user };
            var result = await _commandExecutor.Execute(command);
            return new RegisterUserResponse() { Data = _mapper.Map<UserDTO>(result) };
        }
    }
}
