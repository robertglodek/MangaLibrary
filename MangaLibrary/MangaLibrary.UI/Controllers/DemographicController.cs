using MangaLibrary.ApplicationServices.API.Domain;
using MangaLibrary.ApplicationServices.API.Domain.Demographic;
using MangaLibrary.DataAccess.Data.FixedData;
using MangaLibrary.UI.ApiModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangaLibrary.UI.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/demographic")]
    [ApiController]
    public class DemographicController : ApiControllerBase
    {

        public DemographicController(IMediator mediator, ILogger<DemographicController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetDemographicsResponse), 200)]
        public Task<IActionResult> GetAll()
        {
            return this.HandleRequest<GetDemographicsRequest, GetDemographicsResponse>(new GetDemographicsRequest());
        }
        
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(GetDemographicByIdResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            var request = new GetDemographicByIdRequest() { Id = id };
            return this.HandleRequest<GetDemographicByIdRequest, GetDemographicByIdResponse>(request);
        }

        [HttpPost]
        [Authorize(Roles = UserRole.Admin)]
        [ProducesResponseType(typeof(AddDemographicResponse), 200)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> Add([FromBody] AddDemographicRequest request)
        {
            return this.HandleRequest<AddDemographicRequest, AddDemographicResponse>(request);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = UserRole.Admin)]
        [ProducesResponseType(typeof(UpdateDemographicResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        [ProducesResponseType(typeof(IEnumerable<Error>), 400)]
        public Task<IActionResult> Update([FromBody] UpdateDemographicRequest request,[FromRoute]Guid id)
        {
            if (request != null)
            {
                request.Id = id;
                this.ReValidateModel(request);
            }
            return this.HandleRequest<UpdateDemographicRequest, UpdateDemographicResponse>(request);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = UserRole.Admin)]
        [ProducesResponseType(typeof(DeleteDemographicResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponseBase), 404)]
        public Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var request = new DeleteDemographicRequest() { Id = id };
            return this.HandleRequest<DeleteDemographicRequest, DeleteDemographicResponse>(request);
        }
    }
}
