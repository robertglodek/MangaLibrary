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

        [HttpPost]
        public Task<IActionResult> Add([FromBody] AddMangaRequest request)
        {
            return this.HandleRequest<AddMangaRequest, AddMangaResponse>(request);
        }

        [HttpPut]
        public Task<IActionResult> Update([FromBody] UpdateMangaRequest request)
        {
            return this.HandleRequest<UpdateMangaRequest, UpdateMangaResponse>(request);
        }

        [HttpDelete]
        [Route("{Id}")]
        public Task<IActionResult> Delete([FromRoute] DeleteMangaRequest request)
        {
            return this.HandleRequest<DeleteMangaRequest, DeleteMangaResponse>(request);
        }
    }
}
