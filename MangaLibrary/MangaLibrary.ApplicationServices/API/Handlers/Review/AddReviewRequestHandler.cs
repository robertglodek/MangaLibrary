using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models.Review;
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
    public class AddReviewRequestHandler : IRequestHandler<AddReviewRequest, AddReviewResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public AddReviewRequestHandler(ICommandExecutor commandExecutor, IMapper mapper,IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }
        public async Task<AddReviewResponse> Handle(AddReviewRequest request, CancellationToken cancellationToken)
        {
            var mangaExists = await _queryExecutor.Execute(new ResourceExistsQuery<MangaLibrary.DataAccess.Entities.Manga>() { Id = request.MangaId });
            if (!mangaExists)
                return new AddReviewResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"Manga with id: {request.MangaId} doesn't exist") };

            var userExists = await _queryExecutor.Execute(new ResourceExistsQuery<MangaLibrary.DataAccess.Entities.User>() { Id = request.AuthorId });
            if (!userExists)
                return new AddReviewResponse() { Error = new Domain.ErrorModel(ErrorType.NotFound, $"User with id: {request.MangaId} doesn't exist") };

            var item = _mapper.Map<MangaLibrary.DataAccess.Entities.Review>(request);
            var command = new AddResourceCommand<MangaLibrary.DataAccess.Entities.Review>() { Parameter = item };
            var result = await _commandExecutor.Execute(command);
            return new AddReviewResponse() { Data = _mapper.Map<ReviewDTO>(result) };
        }
    }
}
