using MangaLibrary.ApplicationServices.API.Domain;
using MangaLibrary.ApplicationServices.API.Domain.Review;
using MangaLibrary.DataAccess.Data.FixedData;
using MangaLibrary.UI.ApiModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.UI.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/manga/{mangaId}/review")]
    [ApiController]
    public class ReviewController : ApiControllerBase
    {
        public ReviewController(IMediator mediator, ILogger<ReviewController> logger) : base(mediator, logger)
        {

        }

        [HttpGet]
        [ProducesResponseType(typeof(GetReviewsResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> GetAll([FromQuery]GetReviewsRequest request, [FromRoute] Guid mangaId)
        {
            if (request != null)
                request.MangaId = mangaId;
            return this.HandleRequest<GetReviewsRequest, GetReviewsResponse>(request);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(GetReviewByIdResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        public Task<IActionResult> Get([FromRoute]Guid mangaId, [FromRoute] Guid id)
        {
            var request = new GetReviewByIdRequest() { Id=id, MangaId=mangaId};
            return this.HandleRequest<GetReviewByIdRequest, GetReviewByIdResponse>(request);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddReviewResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        [Authorize(Roles = UserRole.User)]
        public Task<IActionResult> Add([FromBody] AddReviewRequest request, [FromRoute] Guid mangaId)
        {
            if (request != null)
                request.MangaId = mangaId;
            return this.HandleRequest<AddReviewRequest, AddReviewResponse>(request);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateReviewResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        [Authorize(Roles = UserRole.User)]
        public Task<IActionResult> Update([FromBody] UpdateReviewRequest request, [FromRoute] Guid id, [FromRoute] Guid mangaId)
        {
            if (request != null)
            {
                request.Id = id;
                request.MangaId = mangaId;
            }
            return this.HandleRequest<UpdateReviewRequest, UpdateReviewResponse>(request);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(DeleteReviewResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        [Authorize(Roles = UserRole.Admin)]
        public Task<IActionResult> Delete([FromRoute] Guid mangaId, [FromRoute] Guid id)
        {
            var request = new DeleteReviewRequest() { Id = id, MangaId = mangaId };
            return this.HandleRequest<DeleteReviewRequest, DeleteReviewResponse>(request);
        }
    }
}
