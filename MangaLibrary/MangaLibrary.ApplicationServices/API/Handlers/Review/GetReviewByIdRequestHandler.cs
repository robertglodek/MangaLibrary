using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models.Review;
using MangaLibrary.ApplicationServices.API.Domain.Review;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MangaLibrary.DataAccess.CQRS.Queries;
using MangaLibrary.DataAccess.CQRS.Queries.Generic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Handlers.Review
{

    public class GetReviewByIdRequestHandler : IRequestHandler<GetReviewByIdRequest, GetReviewByIdResponse>
    {
        private readonly IQueryExecutor _executor;
        private readonly IMapper _mapper;

        public GetReviewByIdRequestHandler(IQueryExecutor executor, IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        public async Task<GetReviewByIdResponse> Handle(GetReviewByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetResourceQuery<MangaLibrary.DataAccess.Entities.Review>() { Id = request.Id, PropertiesToInclude = "Author" };
            var result = await _executor.Execute(query);
            if (result == null)
                return new GetReviewByIdResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Review with id: {request.Id} doesn't exist") };
            return new GetReviewByIdResponse() { Data = _mapper.Map<ReviewDetailsDTO>(result) };
        }
    }
}
