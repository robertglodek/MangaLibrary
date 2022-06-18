﻿using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models;
using MangaLibrary.ApplicationServices.API.Domain.User;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.User
{
    public class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IQueryExecutor _executor;
        private readonly IMapper _mapper;

        public GetUserByIdRequestHandler(IQueryExecutor executor,IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery() { Id = request.Id };
            var result = await _executor.Execute(query);
            if (!result.IsSuccess)
                return new GetUserByIdResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, result.ErrorMessage) };
            return new GetUserByIdResponse() { Data = _mapper.Map<UserDTO>(result.Value) };


        }
    }
}
