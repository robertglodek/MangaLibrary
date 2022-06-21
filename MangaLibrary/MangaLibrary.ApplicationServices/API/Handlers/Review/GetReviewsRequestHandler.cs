using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models.Review;
using MangaLibrary.ApplicationServices.API.Domain.Review;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.Review;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Review
{
 
    public class GetReviewsRequestHandler : IRequestHandler<GetReviewsRequest, GetReviewsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _executor;

        public GetReviewsRequestHandler(IMapper mapper, IQueryExecutor executor)
        {
            _mapper = mapper;
            _executor = executor;
        }
        public async Task<GetReviewsResponse> Handle(GetReviewsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetReviewsQuery()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                SortBy = request.SortBy,
                SortDirection = request.SortDirection
            };
            var result = await _executor.Execute(query);
            return new GetReviewsResponse()
            {
                Data = new Domain.PagedResult<ReviewDetailsDTO>(_mapper.Map<List<ReviewDetailsDTO>>(result.Items)
                , result.TotalItemsCount
                , request.PageSize
                , request.PageNumber)
            };
        }
    }
}
