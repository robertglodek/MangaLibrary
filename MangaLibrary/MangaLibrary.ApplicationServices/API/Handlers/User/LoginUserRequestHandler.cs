using MangaLibrary.ApplicationServices.API.Domain.User;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MangaLibrary.ApplicationServices.Utilities;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.User
{
    public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly IQueryExecutor _executor;
        private readonly Microsoft.AspNetCore.Identity.IPasswordHasher<MangaLibrary.DataAccess.Entities.User> _passwordHasher;
        private readonly IOptions<AuthenticationSettings> _authenticationSettings;

        public LoginUserRequestHandler(IQueryExecutor executor
            ,IPasswordHasher<MangaLibrary.DataAccess.Entities.User> passwordHasher
            ,IOptions<AuthenticationSettings> authenticationSettings)
        {
            _executor = executor;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }
        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {

            var result = await _executor.Execute(new GetUserByEmailQuery() { Email = request.Email });
            if (!result.IsSuccess)
                return new LoginUserResponse() { Error= new Domain.ErrorModel(ErrorType.BadRequestError, "Invalid username or password")  };

            var verifyResult = _passwordHasher.VerifyHashedPassword(result.Value, result.Value.PasswordHash, request.Password);
            if(verifyResult== PasswordVerificationResult.Failed)
                return new LoginUserResponse() { Error = new Domain.ErrorModel(ErrorType.BadRequestError, "Invalid username or password") };

            var claims = new List<Claim>() 
            {
                new Claim(ClaimTypes.Email,result.Value.Email),
                new Claim(ClaimTypes.NameIdentifier,result.Value.Id.ToString()),
                new Claim(ClaimTypes.Name,$"{result.Value.FirstName} {result.Value.LastName}" ),
                new Claim(ClaimTypes.Role,result.Value.Role.Name),
                new Claim("Nationality",result.Value.Nationality)
            };
            if (result.Value.DateOfBirth != null)
                new Claim("DateOfBirth", result.Value.DateOfBirth.Value.ToString(CultureInfo.InvariantCulture));


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.Value.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.Value.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.Value.JwtIssuer,
                _authenticationSettings.Value.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();

            return new LoginUserResponse() { Data = tokenHandler.WriteToken(token) };
   
        }
    }
}
