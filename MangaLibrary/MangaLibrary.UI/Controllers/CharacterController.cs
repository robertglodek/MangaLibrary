using MangaLibrary.ApplicationServices.API.Domain;
using MangaLibrary.ApplicationServices.API.Domain.Character;
using MangaLibrary.ApplicationServices.API.Domain.Creator;
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
    [Route("api/character")]
    [ApiController]
    public class CharacterController : ApiControllerBase
    {
        public CharacterController(IMediator mediator, ILogger<CharacterController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetCharactersRequest), 200)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> GetAll([FromQuery] GetCharactersRequest request)
        {
            return this.HandleRequest<GetCharactersRequest, GetCharactersResponse>(request);
        }

        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetCharacterByIdResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            var request = new GetCharacterByIdRequest() { Id = id };
            return this.HandleRequest<GetCharacterByIdRequest, GetCharacterByIdResponse>(request);
        }

        [HttpPost]
        [Authorize(Roles = UserRole.Admin)]
        [ProducesResponseType(typeof(AddCharacterResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> Add([FromBody] AddCharacterRequest request)
        {
            return this.HandleRequest<AddCharacterRequest, AddCharacterResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = UserRole.Admin)]
        [ProducesResponseType(typeof(UpdateCharacterResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> Update([FromBody] UpdateCharacterRequest request, [FromRoute] Guid id)
        {
            if (request != null)
                request.Id = id;
            return this.HandleRequest<UpdateCharacterRequest, UpdateCharacterResponse>(request);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = UserRole.Admin)]
        [ProducesResponseType(typeof(DeleteCharacterResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        public Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var request = new DeleteCharacterRequest() { Id = id };
            return this.HandleRequest<DeleteCharacterRequest, DeleteCharacterResponse>(request);
        }
    }
}
