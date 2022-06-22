using MangaLibrary.ApplicationServices.API.Domain.Volume;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.UI.Controllers
{
    [Route("api/manga/{mangaId}/[controller]")]
    [ApiController]
    public class VolumeController : ApiControllerBase
    {
        public VolumeController(IMediator mediator, ILogger<VolumeController> logger) : base(mediator, logger)
        {

        }

        [HttpGet]
        public Task<IActionResult> GetAll(GetVolumesRequest request, [FromRoute] Guid mangaId)
        {
            request.MangaId = mangaId;
            return this.HandleRequest<GetVolumesRequest, GetVolumesResponse>(request);
        }

        [HttpGet]
        [Route("{Id}")]
        public Task<IActionResult> Get([FromRoute] Guid mangaId, [FromRoute] Guid id)
        {
            var request = new GetVolumeByIdRequest() { Id = id, MangaId = mangaId };
            return this.HandleRequest<GetVolumeByIdRequest, GetVolumeByIdResponse>(request);
        }

        [HttpPost]
        public Task<IActionResult> Add([FromBody] AddVolumeRequest request, [FromRoute] Guid mangaId)
        {
            request.MangaId = mangaId;
            return this.HandleRequest<AddVolumeRequest, AddVolumeResponse>(request);
        }

        [HttpPut("{id}")]
        public Task<IActionResult> Update([FromBody] UpdateVolumeRequest request, [FromRoute] Guid id, [FromRoute] Guid mangaId)
        {
            request.Id = id;
            request.MangaId = mangaId;
            return this.HandleRequest<UpdateVolumeRequest, UpdateVolumeResponse>(request);
        }

        [HttpDelete]
        [Route("{Id}")]
        public Task<IActionResult> Delete([FromRoute] Guid mangaId, [FromRoute] Guid id)
        {
            var request = new DeleteVolumeRequest() { Id = id, MangaId = mangaId };
            return this.HandleRequest<DeleteVolumeRequest, DeleteVolumeResponse>(request);
        }
    }
}
