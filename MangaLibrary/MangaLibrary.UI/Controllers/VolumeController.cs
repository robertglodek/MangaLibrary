using MangaLibrary.ApplicationServices.API.Domain;
using MangaLibrary.ApplicationServices.API.Domain.Volume;
using MangaLibrary.UI.ApiModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.UI.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/manga/{mangaId}/[controller]")]
    [ApiController]
    public class VolumeController : ApiControllerBase
    {
        public VolumeController(IMediator mediator, ILogger<VolumeController> logger) : base(mediator, logger)
        {

        }
   
        [HttpGet]
        [ProducesResponseType(typeof(GetVolumesResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> GetAll([FromQuery] GetVolumesRequest request, [FromRoute] Guid mangaId)
        {
            if (request != null)
                request.MangaId = mangaId;
            return this.HandleRequest<GetVolumesRequest, GetVolumesResponse>(request);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(GetVolumeByIdResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        public Task<IActionResult> Get([FromRoute] Guid mangaId, [FromRoute] Guid id)
        {
            var request = new GetVolumeByIdRequest() { Id = id, MangaId = mangaId };
            return this.HandleRequest<GetVolumeByIdRequest, GetVolumeByIdResponse>(request);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddVolumeResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> Add([FromBody] AddVolumeRequest request, [FromRoute] Guid mangaId)
        {
            if (request != null)
                request.MangaId = mangaId;
            return this.HandleRequest<AddVolumeRequest, AddVolumeResponse>(request);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateVolumeResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> Update([FromBody] UpdateVolumeRequest request, [FromRoute] Guid id, [FromRoute] Guid mangaId)
        {
            if (request != null)
            {
                request.Id = id;
                request.MangaId = mangaId;
                this.ReValidateModel(request);
            }
           
            return this.HandleRequest<UpdateVolumeRequest, UpdateVolumeResponse>(request);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(DeleteVolumeResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        public Task<IActionResult> Delete([FromRoute] Guid mangaId, [FromRoute] Guid id)
        {
            var request = new DeleteVolumeRequest() { Id = id, MangaId = mangaId };
            return this.HandleRequest<DeleteVolumeRequest, DeleteVolumeResponse>(request);
        }
    }
}
