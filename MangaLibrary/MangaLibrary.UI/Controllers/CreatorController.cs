using MangaLibrary.ApplicationServices.API.Domain;
using MangaLibrary.ApplicationServices.API.Domain.Creator;
using MangaLibrary.ApplicationServices.API.Domain.Genre;
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
    [Route("api/creator")]
    [ApiController]
    public class CreatorController : ApiControllerBase
    {
        public CreatorController(IMediator mediator, ILogger<CreatorController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetCreatorsResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> GetAll([FromQuery] GetCreatorsRequest request)
        {
            return this.HandleRequest<GetCreatorsRequest, GetCreatorsResponse>(request);
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetCreatorByIdResponse),200)]
        [ProducesResponseType(typeof(ErrorResponseBase),404)]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            var request = new GetCreatorByIdRequest() { Id = id };
            return this.HandleRequest<GetCreatorByIdRequest, GetCreatorByIdResponse>(request);
        }

        [HttpPost]
        [Authorize(Roles = UserRole.Admin)]
        [ProducesResponseType(typeof(AddCreatorResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> Add([FromBody] AddCreatorRequest request)
        {
            return this.HandleRequest<AddCreatorRequest, AddCreatorResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = UserRole.Admin)]
        [ProducesResponseType(typeof(UpdateCreatorResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> Update([FromBody] UpdateCreatorRequest request,[FromRoute]Guid id)
        {
            if (request != null)
                request.Id = id;
            return this.HandleRequest<UpdateCreatorRequest, UpdateCreatorResponse>(request);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = UserRole.Admin)]
        [ProducesResponseType(typeof(DeleteCreatorResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        public Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var request = new DeleteCreatorRequest() { Id=id};
            return this.HandleRequest<DeleteCreatorRequest, DeleteCreatorResponse>(request);
        }
    }
}
