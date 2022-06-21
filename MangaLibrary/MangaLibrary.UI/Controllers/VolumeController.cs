using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.UI.Controllers
{
    [Route("api/manga/{mangaId}/[controller]")]
    [ApiController]
    public class VolumeController : ApiControllerBase
    {
        public VolumeController(IMediator mediator, ILogger<VolumeController> logger) : base(mediator, logger)
        {

        }
    }
}
