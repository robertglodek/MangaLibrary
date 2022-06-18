using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MangaLibrary.ApplicationServices.API.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ApiControllerBase
    {
        public GenreController(IMediator mediator,ILogger<GenreController> logger):base(mediator,logger)
        {

        }
        [HttpGet]
        public Task<IActionResult> GetAll()
        {
            return this.HandleRequest<GetGenresRequest,GetGenresResponse>(new GetGenresRequest());
        }

        [HttpGet]
        [Route("{Id}")]
        public Task<IActionResult> Get([FromRoute] GetGenreByIdRequest request)
        {
            return this.HandleRequest<GetGenreByIdRequest, GetGenreByIdResponse>(request);   
        }

        [HttpPost]
        public Task<IActionResult> Add([FromBody] AddGenreRequest request)
        {
            return this.HandleRequest<AddGenreRequest, AddGenreResponse>(request);
        }

        [HttpPut]
        public Task<IActionResult> Update([FromBody] UpdateGenreRequest request)
        {
            return this.HandleRequest<UpdateGenreRequest, UpdateGenreResponse>(request);    
        }

        [HttpDelete]
        [Route("{Id}")]
        public Task<IActionResult> Delete([FromRoute] DeleteGenreRequest request)
        {
            return this.HandleRequest<DeleteGenreRequest, DeleteGenreResponse>(request); 
        }
    } 
}
