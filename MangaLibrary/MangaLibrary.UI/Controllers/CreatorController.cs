using MangaLibrary.ApplicationServices.API.Domain.Creator;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatorController : ApiControllerBase
    {
        public CreatorController(IMediator mediator, ILogger<CreatorController> logger):base(mediator, logger)
        {

        }


        //[HttpGet]
        //public Task<IActionResult> GetAll()
        //{
        //    return this.HandleRequest<GetGenresRequest, GetGenresResponse>(new GetGenresRequest());
        //}

        //[HttpGet]
        //[Route("{Id}")]
        //public Task<IActionResult> Get([FromRoute] GetGenreByIdRequest request)
        //{
        //    return this.HandleRequest<GetGenreByIdRequest, GetGenreByIdResponse>(request);
        //}

        [HttpPost]
        public Task<IActionResult> Add([FromBody] AddCreatorRequest request)
        {
            return this.HandleRequest<AddCreatorRequest, AddCreatorResponse>(request);
        }

        //[HttpPut]
        //public Task<IActionResult> Update([FromBody] UpdateGenreRequest request)
        //{
        //    return this.HandleRequest<UpdateGenreRequest, UpdateGenreResponse>(request);
        //}

        //[HttpDelete]
        //[Route("{Id}")]
        //public Task<IActionResult> Delete([FromRoute] DeleteGenreRequest request)
        //{
        //    return this.HandleRequest<DeleteGenreRequest, DeleteGenreResponse>(request);
        //}



    }
}
