using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.UI.Controllers
{
    [Route("api/manga/{mangaId}/[controller]")]
    [ApiController]
    public class ReviewController : ApiControllerBase
    {
        public ReviewController(IMediator mediator, ILogger<ReviewController> logger) : base(mediator, logger)
        {

        }
    }
}
