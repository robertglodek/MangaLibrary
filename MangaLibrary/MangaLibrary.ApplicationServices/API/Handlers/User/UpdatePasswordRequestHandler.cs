using AutoMapper;
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
    public class UpdatePasswordRequestHandler : IRequestHandler<UpdatePasswordRequest, UpdatePasswordResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<DataAccess.Entities.User> _passwordHasher;

        public UpdatePasswordRequestHandler(ICommandExecutor commandExecutor
            , IQueryExecutor queryExecutor
            , IMapper mapper
            , IPasswordHasher<DataAccess.Entities.User> passwordHasher)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public async Task<UpdatePasswordResponse> Handle(UpdatePasswordRequest request, CancellationToken cancellationToken)
        {
            var item = await _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.User>() { Id = request.Id });
            if (item == null)
                return new UpdatePasswordResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"User with id: {request.Id} doesn't exist") };

            var verifyResult = _passwordHasher.VerifyHashedPassword(item, item.PasswordHash, request.OldPassword);
            if (verifyResult == PasswordVerificationResult.Failed)
                return new UpdatePasswordResponse() { Error = new Domain.ErrorModel(ErrorType.NotAuthenticated, "Old password invalid") };

            item.PasswordHash = _passwordHasher.HashPassword(item, request.NewPassword);

            var command = new UpdateResourceCommand<MangaLibrary.DataAccess.Entities.User>() { Parameter = item };
            var result = await _commandExecutor.Execute(command);
            return new UpdatePasswordResponse() { Data = item.Id };

        }
    }
}
