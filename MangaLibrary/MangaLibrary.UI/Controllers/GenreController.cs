using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MangaLibrary.ApplicationServices.API.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;

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
        [Route("{id}")]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            var request = new GetGenreByIdRequest() { Id = id };
            return this.HandleRequest<GetGenreByIdRequest, GetGenreByIdResponse>(request);   
        }

        [HttpPost]
        public Task<IActionResult> Add([FromBody] AddGenreRequest request)
        {
            return this.HandleRequest<AddGenreRequest, AddGenreResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> Update([FromBody] UpdateGenreRequest request, [FromRoute] Guid id)
        {
            request.Id = id;
            return this.HandleRequest<UpdateGenreRequest, UpdateGenreResponse>(request);    
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var request = new DeleteGenreRequest() { Id = id };
            return this.HandleRequest<DeleteGenreRequest, DeleteGenreResponse>(request); 
        }
    } 
}
