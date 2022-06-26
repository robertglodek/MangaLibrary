using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models.Role;
using MangaLibrary.ApplicationServices.API.Domain.Role;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Role
{
    public class GetRoleByIdRequestHandler : IRequestHandler<GetRoleByIdRequest, GetRoleByIdResponse>
    {
        private readonly IQueryExecutor _executor;
        private readonly IMapper _mapper;

        public GetRoleByIdRequestHandler(IQueryExecutor executor, IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        public async Task<GetRoleByIdResponse> Handle(GetRoleByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetResourceQuery<MangaLibrary.DataAccess.Entities.Role>() { Id = request.Id };
            var result = await _executor.Execute(query);
            if (result == null)
                return new GetRoleByIdResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Role with id: {request.Id} doesn't exist") };
            return new GetRoleByIdResponse() { Data = _mapper.Map<RoleDTO>(result) };
        }
    }
}
