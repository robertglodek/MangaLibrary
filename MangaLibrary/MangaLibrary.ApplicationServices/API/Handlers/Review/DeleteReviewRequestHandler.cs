using MangaLibrary.ApplicationServices.API.Domain.Review;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.CQRS.Commands.Generic;
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
    public class DeleteReviewRequestHandler : IRequestHandler<DeleteReviewRequest, DeleteReviewResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;
        public DeleteReviewRequestHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }
        public async Task<DeleteReviewResponse> Handle(DeleteReviewRequest request, CancellationToken cancellationToken)
        {
            var getMangaResult = await _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.Manga>() { Id = request.MangaId });
            if (getMangaResult == null)
                return new DeleteReviewResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Manga with id: {request.MangaId} doesn't exist") };

            var getReviewResult = await _queryExecutor.Execute(new GetResourceQuery<MangaLibrary.DataAccess.Entities.Review>() { Id = request.Id });
            if (getReviewResult == null || getReviewResult.MangaId != getMangaResult.Id)
                return new DeleteReviewResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Review with id: {request.MangaId} and mangaId:{request.MangaId}  doesn't exist") };

            var command = new DeleteResourceCommand<MangaLibrary.DataAccess.Entities.Review>() { Parameter = getReviewResult };
            var result = await _commandExecutor.Execute(command);
            return new DeleteReviewResponse() { Data = result };
        }
    }
}
