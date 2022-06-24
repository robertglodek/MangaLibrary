using MangaLibrary.ApplicationServices.API.Domain;
using MangaLibrary.ApplicationServices.API.Domain.Creator;
using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MangaLibrary.UI.ApiModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.UI.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CreatorController : ApiControllerBase
    {
        public CreatorController(IMediator mediator, ILogger<CreatorController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetCreatorsResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> GetAll([FromQuery] GetCreatorsRequest request)
        {
            return this.HandleRequest<GetCreatorsRequest, GetCreatorsResponse>(request);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(GetCreatorByIdResponse),200)]
        [ProducesResponseType(typeof(ErrorResponseBase),404)]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            var request = new GetCreatorByIdRequest() { Id = id };
            return this.HandleRequest<GetCreatorByIdRequest, GetCreatorByIdResponse>(request);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddCreatorResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> Add([FromBody] AddCreatorRequest request)
        {
            return this.HandleRequest<AddCreatorRequest, AddCreatorResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
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
        [ProducesResponseType(typeof(DeleteCreatorResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        public Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var request = new DeleteCreatorRequest() { Id=id};
            return this.HandleRequest<DeleteCreatorRequest, DeleteCreatorResponse>(request);
        }
    }
}
