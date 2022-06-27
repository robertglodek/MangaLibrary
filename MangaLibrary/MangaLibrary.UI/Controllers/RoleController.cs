using MangaLibrary.ApplicationServices.API.Domain;
using MangaLibrary.ApplicationServices.API.Domain.Demographic;
using MangaLibrary.ApplicationServices.API.Domain.Role;
using MangaLibrary.DataAccess.Data.FixedData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.UI.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/role")]
    [ApiController]
    public class RoleController : ApiControllerBase
    {
        public RoleController(IMediator mediator, ILogger<RoleController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetRolesResponse), 200)]
        public Task<IActionResult> GetAll()
        {
            return this.HandleRequest<GetRolesRequest, GetRolesResponse>(new GetRolesRequest());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(GetRoleByIdResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            var request = new GetRoleByIdRequest() { Id = id };
            return this.HandleRequest<GetRoleByIdRequest, GetRoleByIdResponse>(request);
        }
    }
}
