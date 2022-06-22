using MangaLibrary.ApplicationServices.API.Domain.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        public UserController(IMediator mediator, ILogger<UserController> logger) : base(mediator, logger)
        {
        }

        [HttpPost]
        [Route("register")]
        public Task<IActionResult> Register(RegisterUserRequest request)
        {
            return this.HandleRequest<RegisterUserRequest, RegisterUserResponse>(request);

        }

        [HttpPost]
        [Route("login")]
        public Task<IActionResult> Login(LoginUserRequest request)
        {
            return this.HandleRequest<LoginUserRequest, LoginUserResponse>(request);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            var request = new GetUserByIdRequest();
            return this.HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);
        }

        [HttpGet]
        public Task<IActionResult> GetAll()
        {
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(new GetUsersRequest());
        }

        [HttpPut]
        [Route("password/{id}")]
        public Task<IActionResult> ChangePassword([FromRoute]Guid id, [FromBody] UpdatePasswordRequest request)
        {
            request.Id = id;
            return this.HandleRequest<UpdatePasswordRequest, UpdatePasswordResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserRequest request)
        {
            request.Id = id;
            return this.HandleRequest<UpdateUserRequest, UpdateUserResponse>(request);
        }
        [HttpDelete]
        [Route("{id}")]
        public Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var request = new DeleteUserRequest() { Id = id };
            return this.HandleRequest<DeleteUserRequest, DeleteUserResponse>(request);
        }
    }
}
