using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MangaLibrary.ApplicationServices.API.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetGenreResponse>> Get()
        {
            var request = new GetGenresRequest();
            var result = await _mediator.Send(request);
            return Ok(result);
        }


        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult<GetGenreResponse>> Get([FromRoute] GetGenreRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<AddGenreResponse>> Add([FromBody] AddGenreRequest request)
        {
            var result = await _mediator.Send(request);
            return Created($"/api/genre/{result.Data.Id}",result);
        }


        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateGenreRequest request)
        {
            var result = await _mediator.Send(request);
            return NoContent();
        }

     
        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult> Delete([FromRoute] DeleteGenreRequest request)
        {
            var result = await _mediator.Send(request);
            return NoContent();
        }

    }
}
