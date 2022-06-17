using MangaLibrary.ApplicationServices.API.Domain.User;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.User
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly IQueryExecutor _executor;
        private readonly Microsoft.AspNetCore.Identity.IPasswordHasher<MangaLibrary.DataAccess.Entities.User> _passwordHasher;

        public LoginUserHandler(IQueryExecutor executor,IPasswordHasher<MangaLibrary.DataAccess.Entities.User> passwordHasher)
        {
            _executor = executor;
            _passwordHasher = passwordHasher;
        }
        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {

            var result = await _executor.Execute(new GetUserByEmailQuery() { Email = request.Email });
            if (!result.IsSuccess)
                return new LoginUserResponse() { Error= new Domain.ErrorModel(ErrorType.BadRequestError, "Invalid username or password")  };

            var verifyResult = _passwordHasher.VerifyHashedPassword(result.Value, result.Value.PasswordHash, request.Password);
            if(verifyResult== PasswordVerificationResult.Failed)
                return new LoginUserResponse() { Error = new Domain.ErrorModel(ErrorType.BadRequestError, "Invalid username or password") };







            throw new NotImplementedException();
        }
    }
}
