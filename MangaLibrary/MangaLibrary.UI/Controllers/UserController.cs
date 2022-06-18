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
        [Route("{Id}")]
        public Task<IActionResult> Get([FromRoute] GetUserByIdRequest request)
        {
            return this.HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);
        }

        [HttpGet]
        public Task<IActionResult> GetAll()
        {
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(new GetUsersRequest());
        }



        //[HttpPut]
        //[Route("password")]
        //public Task<IActionResult> ChangePassword()
        //{

        //}

        //[HttpPut]
        //public Task<IActionResult> Update()
        //{

        //}



    }
}
