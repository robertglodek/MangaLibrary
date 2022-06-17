using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.User;
using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.CQRS.Commands.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.User
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {
        private readonly ICommandExecutor _executor;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<DataAccess.Entities.User> _passwordHasher;

        public RegisterUserHandler(ICommandExecutor executor,IMapper mapper,
            IPasswordHasher<MangaLibrary.DataAccess.Entities.User> passwordHasher)
        {
            _executor = executor;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public async Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<MangaLibrary.DataAccess.Entities.User>(request);
            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);
            var command = new AddUserCommand() { Parameter = user };
            var result = await _executor.Execute(command);
            return new RegisterUserResponse() { Data = result.Value };
        }
    }
}
