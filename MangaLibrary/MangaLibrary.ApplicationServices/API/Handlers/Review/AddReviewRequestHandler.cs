using AutoMapper;
using MangaLibrary.ApplicationServices.API.Domain.Models.Review;
using MangaLibrary.ApplicationServices.API.Domain.Review;
using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.CQRS.Commands.Generic;
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
        private readonly ICommandExecutor _executor;
        private readonly IMapper _mapper;

        public AddReviewRequestHandler(ICommandExecutor executor, IMapper mapper)
        {
            _executor = executor;
            _mapper = mapper;
        }
        public async Task<AddReviewResponse> Handle(AddReviewRequest request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<MangaLibrary.DataAccess.Entities.Review>(request);
            var command = new AddResourceCommand<MangaLibrary.DataAccess.Entities.Review>() { Parameter = item };
            var result = await _executor.Execute(command);
            return new AddReviewResponse() { Data = _mapper.Map<ReviewDTO>(result) };
        }
    }
}
