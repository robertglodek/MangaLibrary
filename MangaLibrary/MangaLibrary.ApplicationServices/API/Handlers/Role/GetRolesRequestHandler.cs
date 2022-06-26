using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models.Role;
using MangaLibrary.ApplicationServices.API.Domain.Role;
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
    public class GetRolesRequestHandler : IRequestHandler<GetRolesRequest, GetRolesResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _executor;

        public GetRolesRequestHandler(IMapper mapper, IQueryExecutor executor)
        {
            _mapper = mapper;
            _executor = executor;
        }
        public async Task<GetRolesResponse> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetResourcesQuery<MangaLibrary.DataAccess.Entities.Role>();
            var result = await _executor.Execute(query);
            return new GetRolesResponse() { Data = _mapper.Map<List<RoleDTO>>(result) };
        }
    }
}
