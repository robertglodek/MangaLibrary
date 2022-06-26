using MangaLibrary.ApplicationServices.API.Domain;
using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MangaLibrary.ApplicationServices.API.Domain.Manga;
using MangaLibrary.ApplicationServices.API.Domain.Models;
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
    [Route("api/manga")]
    [ApiController]
    public class MangaController : ApiControllerBase
    {
        public MangaController(IMediator mediator, ILogger<MangaController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetMangasResponse), 200)]
        public Task<IActionResult> GetAll([FromQuery] GetMangasRequest request)
        {
            return this.HandleRequest<GetMangasRequest, GetMangasResponse>(request);
        }


        [HttpGet]
        [Route("external")]
        [ProducesResponseType(typeof(GetMangasExternalResponse), 200)]
        public Task<IActionResult> GetAllExternal([FromQuery] GetMangasExternalRequest request)
        {
            return this.HandleRequest<GetMangasExternalRequest, GetMangasExternalResponse>(request);
        }


        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(GetMangaByIdResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            var request = new GetMangaByIdRequest() { Id = id };
            return this.HandleRequest<GetMangaByIdRequest, GetMangaByIdResponse>(request);
        }

        [HttpPost]
        [Authorize(Roles = UserRole.Admin)]
        [ProducesResponseType(typeof(AddMangaResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> Add([FromBody] AddMangaRequest request)
        {
            return this.HandleRequest<AddMangaRequest, AddMangaResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = UserRole.Admin)]
        [ProducesResponseType(typeof(UpdateMangaResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> Update([FromBody] UpdateMangaRequest request, [FromRoute] Guid id)
        {
            if (request != null)
            {
                request.Id = id;
                this.ReValidateModel(request);
            }
            return this.HandleRequest<UpdateMangaRequest, UpdateMangaResponse>(request);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = UserRole.Admin)]
        [ProducesResponseType(typeof(DeleteMangaResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        public Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var request = new DeleteMangaRequest() { Id = id };
            return this.HandleRequest<DeleteMangaRequest, DeleteMangaResponse>(request);
        }


    }
}
