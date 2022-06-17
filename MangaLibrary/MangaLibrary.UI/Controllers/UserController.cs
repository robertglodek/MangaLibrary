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
        public Task<IActionResult> Register()
        {

        }

        [HttpPost]
        [Route("login")]
        public Task<IActionResult> Register()
        {

        }

        [HttpGet]
        public Task<IActionResult> GetAll()
        {

        }

    }
}
