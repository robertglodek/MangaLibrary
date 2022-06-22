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
            var getMangaResult = await _executor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.Manga>() { Id = request.MangaId });
            if (getMangaResult == null)
                return new GetReviewByIdResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Manga with id: {request.MangaId} doesn't exist") };

            var getReviewResult = await _executor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.Review>() { Id = request.Id, PropertiesToInclude = "Author" });
            if (getReviewResult == null || getReviewResult.MangaId!=getMangaResult.Id)
                return new GetReviewByIdResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Review with id: {request.MangaId} and mangaId:{request.MangaId}  doesn't exist") };

            return new GetReviewByIdResponse() { Data = _mapper.Map<ReviewDetailsDTO>(getReviewResult) };
        }
    }
}
