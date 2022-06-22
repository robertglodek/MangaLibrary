using MangaLibrary.ApplicationServices.API.Domain.Creator;
using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatorController : ApiControllerBase
    {
        public CreatorController(IMediator mediator, ILogger<CreatorController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Authorize]
        public Task<IActionResult> GetAll([FromQuery] GetCreatorsRequest request)
        {
            return this.HandleRequest<GetCreatorsRequest, GetCreatorsResponse>(request);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            var request = new GetCreatorByIdRequest() { Id = id };
            return this.HandleRequest<GetCreatorByIdRequest, GetCreatorByIdResponse>(request);
        }

        [HttpPost]
        public Task<IActionResult> Add([FromBody] AddCreatorRequest request)
        {
            return this.HandleRequest<AddCreatorRequest, AddCreatorResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> Update([FromBody] UpdateCreatorRequest request,[FromRoute]Guid id)
        {
            request.Id= id;
            return this.HandleRequest<UpdateCreatorRequest, UpdateCreatorResponse>(request);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var request = new DeleteCreatorRequest() { Id=id};
            return this.HandleRequest<DeleteCreatorRequest, DeleteCreatorResponse>(request);
        }
    }
}
