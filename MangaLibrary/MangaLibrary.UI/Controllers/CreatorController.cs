using MangaLibrary.ApplicationServices.API.Domain.Creator;
using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatorController : ApiControllerBase
    {
        public CreatorController(IMediator mediator, ILogger<CreatorController> logger):base(mediator, logger)
        {
        }

        [HttpGet]
        public Task<IActionResult> GetAll([FromQuery] GetCreatorsRequest request)
        {
            return this.HandleRequest<GetCreatorsRequest, GetCreatorsResponse>(request);
        }

        [HttpGet]
        [Route("{Id}")]
        public Task<IActionResult> Get([FromRoute] GetCreatorByIdRequest request)
        {
            return this.HandleRequest<GetCreatorByIdRequest, GetCreatorByIdResponse>(request);
        }

        [HttpPost]
        public Task<IActionResult> Add([FromBody] AddCreatorRequest request)
        {
            return this.HandleRequest<AddCreatorRequest, AddCreatorResponse>(request);
        }

        [HttpPut]
        public Task<IActionResult> Update([FromBody] UpdateCreatorRequest request)
        {
            return this.HandleRequest<UpdateCreatorRequest, UpdateCreatorResponse>(request);
        }

        [HttpDelete]
        [Route("{Id}")]
        public Task<IActionResult> Delete([FromRoute] DeleteCreatorRequest request)
        {
            return this.HandleRequest<DeleteCreatorRequest, DeleteCreatorResponse>(request);
        }
    }
}
