using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MangaLibrary.ApplicationServices.API.Domain.Manga;
using MangaLibrary.ApplicationServices.API.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangaController : ApiControllerBase
    {
        public MangaController(IMediator mediator, ILogger<MangaController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        public Task<IActionResult> GetAll()
        {
            return this.HandleRequest<GetMangasRequest, GetMangasResponse>(new GetMangasRequest());
        }

        [HttpGet]
        [Route("{id}")]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            var request = new GetMangaByIdRequest() { Id = id };
            return this.HandleRequest<GetMangaByIdRequest, GetMangaByIdResponse>(request);
        }

        [HttpPost]
        public Task<IActionResult> Add([FromBody] AddMangaRequest request)
        {
            return this.HandleRequest<AddMangaRequest, AddMangaResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> Update([FromBody] UpdateMangaRequest request, [FromRoute] Guid id)
        {
            request.Id = id;
            return this.HandleRequest<UpdateMangaRequest, UpdateMangaResponse>(request);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var request = new DeleteMangaRequest() { Id = id };
            return this.HandleRequest<DeleteMangaRequest, DeleteMangaResponse>(request);
        }
    }
}
