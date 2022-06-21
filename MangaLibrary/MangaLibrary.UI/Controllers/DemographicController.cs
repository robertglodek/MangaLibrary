using MangaLibrary.ApplicationServices.API.Domain.Demographic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemographicController : ApiControllerBase
    {

        public DemographicController(IMediator mediator, ILogger<DemographicController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        public Task<IActionResult> GetAll([FromQuery] GetDemographicsRequest request)
        {
            return this.HandleRequest<GetDemographicsRequest, GetDemographicsResponse>(request);
        }

        [HttpGet]
        [Route("{Id}")]
        public Task<IActionResult> Get([FromRoute] GetDemographicByIdRequest request)
        {
            return this.HandleRequest<GetDemographicByIdRequest, GetDemographicByIdResponse>(request);
        }

        [HttpPost]
        public Task<IActionResult> Add([FromBody] AddDemographicRequest request)
        {
            return this.HandleRequest<AddDemographicRequest, AddDemographicResponse>(request);
        }

        [HttpPut]
        public Task<IActionResult> Update([FromBody] UpdateDemographicRequest request)
        {
            return this.HandleRequest<UpdateDemographicRequest, UpdateDemographicResponse>(request);
        }

        [HttpDelete]
        [Route("{Id}")]
        public Task<IActionResult> Delete([FromRoute] DeleteDemographicRequest request)
        {
            return this.HandleRequest<DeleteDemographicRequest, DeleteDemographicResponse>(request);
        }
    }
}
