using MangaLibrary.ApplicationServices.API.Domain;
using MangaLibrary.ApplicationServices.API.Domain.User;
using MangaLibrary.DataAccess.Data.FixedData;
using MangaLibrary.UI.ApiModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MangaLibrary.UI.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/user")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        public UserController(IMediator mediator, ILogger<UserController> logger) : base(mediator, logger)
        {
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(ResponseBase<>), 404)]
        [ProducesResponseType(typeof(RegisterUserResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> Register(RegisterUserRequest request)
        {
            return this.HandleRequest<RegisterUserRequest, RegisterUserResponse>(request);
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(LoginUserResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 401)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> Login(LoginUserRequest request)
        {
            return this.HandleRequest<LoginUserRequest, LoginUserResponse>(request);
        }

        [HttpGet]
        [Authorize(Roles = UserRole.Admin)]
        [Route("{id}")]
        [ProducesResponseType(typeof(GetUserByIdResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            var request = new GetUserByIdRequest() { Id=id};
            return this.HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);
        }

        [HttpGet]
        [Authorize(Roles = UserRole.Admin)]
        [ProducesResponseType(typeof(GetUsersResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> GetAll([FromQuery] GetUsersRequest request)
        {
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        [HttpPut]
        [Route("password_change")]
        [Authorize]
        [ProducesResponseType(typeof(UpdatePasswordResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        [ProducesResponseType(typeof(ErrorResponseBase), 401)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> ChangePassword([FromBody] UpdatePasswordRequest request)
        {
            if (request != null)
                request.Id = Guid.Parse(User.Claims.FirstOrDefault(n => n.Type == ClaimTypes.NameIdentifier).Value);
            return this.HandleRequest<UpdatePasswordRequest, UpdatePasswordResponse>(request);
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(typeof(UpdateUserResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> Update([FromBody] UpdateUserRequest request)
        {
            if (request != null)
                request.Id = Guid.Parse(User.Claims.FirstOrDefault(n => n.Type == ClaimTypes.NameIdentifier).Value);
            return this.HandleRequest<UpdateUserRequest, UpdateUserResponse>(request);
        }


        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = UserRole.Admin)]
        [ProducesResponseType(typeof(DeleteUserResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        public Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var request = new DeleteUserRequest() { Id = id };
            return this.HandleRequest<DeleteUserRequest, DeleteUserResponse>(request);
        }

    }
}
