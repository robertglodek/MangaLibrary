using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models.User;
using MangaLibrary.ApplicationServices.API.Domain.User;
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
    public class GetUsersRequestHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _executor;

        public GetUsersRequestHandler(IMapper mapper, IQueryExecutor executor)
        {
            _mapper = mapper;
            _executor = executor;
        }
        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                SearchPhrase = request.SearchPhrase,
                SortBy = request.SortBy,
                SortDirection = request.SortDirection
            };
            var result = await _executor.Execute(query);
            return new GetUsersResponse()
            {
                Data = new Domain.PagedResult<UserDTO>(_mapper.Map<List<UserDTO>>(result.Items)
                , result.TotalItemsCount
                , request.PageSize
                , request.PageNumber)
            };
        }
    }
}
