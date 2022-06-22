using MangaLibrary.ApplicationServices.API.Domain.Review;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.UI.Controllers
{
    [Route("api/manga/{mangaId}/[controller]")]
    [ApiController]
    public class ReviewController : ApiControllerBase
    {
        public ReviewController(IMediator mediator, ILogger<ReviewController> logger) : base(mediator, logger)
        {

        }

        [HttpGet]
        public Task<IActionResult> GetAll(GetReviewsRequest request, [FromRoute] Guid mangaId)
        {
            request.MangaId = mangaId;
            return this.HandleRequest<GetReviewsRequest, GetReviewsResponse>(request);
        }

        [HttpGet]
        [Route("{Id}")]
        public Task<IActionResult> Get([FromRoute]Guid mangaId, [FromRoute] Guid id)
        {
            var request = new GetReviewByIdRequest() { Id=id, MangaId=mangaId};
            return this.HandleRequest<GetReviewByIdRequest, GetReviewByIdResponse>(request);
        }

        [HttpPost]
        public Task<IActionResult> Add([FromBody] AddReviewRequest request, [FromRoute] Guid mangaId)
        {
            request.MangaId = mangaId;
            return this.HandleRequest<AddReviewRequest, AddReviewResponse>(request);
        }

        [HttpPut("{id}")]
        public Task<IActionResult> Update([FromBody] UpdateReviewRequest request, [FromRoute] Guid id, [FromRoute] Guid mangaId)
        {
            request.Id = id;
            request.MangaId = mangaId;
            return this.HandleRequest<UpdateReviewRequest, UpdateReviewResponse>(request);
        }

        [HttpDelete]
        [Route("{Id}")]
        public Task<IActionResult> Delete([FromRoute] Guid mangaId, [FromRoute] Guid id)
        {
            var request = new DeleteReviewRequest() { Id = id, MangaId = mangaId };
            return this.HandleRequest<DeleteReviewRequest, DeleteReviewResponse>(request);
        }
    }
}
