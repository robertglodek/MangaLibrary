using MangaLibrary.ApplicationServices.API.Domain;
using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MangaLibrary.ApplicationServices.API.Domain.Models;
using MangaLibrary.DataAccess.Data.FixedData;
using MangaLibrary.UI.ApiModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;

namespace MangaLibrary.UI.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ApiControllerBase
    {
        private readonly IMediator mediator;

        public GenreController(IMediator mediator,ILogger<GenreController> logger):base(mediator,logger)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetGenresResponse), 200)]
        public  Task<IActionResult> GetAll()
        {
            return this.HandleRequest<GetGenresRequest,GetGenresResponse>(new GetGenresRequest());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(GetGenreByIdResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            var request = new GetGenreByIdRequest() { Id = id };
            return this.HandleRequest<GetGenreByIdRequest, GetGenreByIdResponse>(request);   
        }

        [HttpPost]
        [Authorize(Roles = UserRole.Admin + "," + UserRole.Editor)]
        [ProducesResponseType(typeof(AddGenreResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> Add([FromBody] AddGenreRequest request)
        {
            return this.HandleRequest<AddGenreRequest, AddGenreResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = UserRole.Admin + "," + UserRole.Editor)]
        [ProducesResponseType(typeof(UpdateGenreResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> Update([FromBody] UpdateGenreRequest request, [FromRoute] Guid id)
        {
            if (request != null)
            {
                request.Id = id;
                this.ReValidateModel(request);
            }
            return this.HandleRequest<UpdateGenreRequest, UpdateGenreResponse>(request);    
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = UserRole.Admin + "," + UserRole.Editor)]
        [ProducesResponseType(typeof(DeleteGenreResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        public Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var request = new DeleteGenreRequest() { Id = id };
            return this.HandleRequest<DeleteGenreRequest, DeleteGenreResponse>(request); 
        }
    } 
}
