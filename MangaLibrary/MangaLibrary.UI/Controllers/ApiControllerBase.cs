using MangaLibrary.ApplicationServices.API.Domain;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MangaLibrary.UI.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }


        protected async Task<IActionResult> HandleRequest<TRequest,TResponse>(TRequest request)
            where TRequest : IRequest<TResponse> 
            where TResponse: ErrorResponseBase
        {
            if(!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState
                    .Where(x=>x.Value.Errors.Any())
                    .Select(x=>new { property=x.Key, errors= x.Value.Errors }));
            }

            var response = await _mediator.Send(request);

            if(response.Error != null)
                return ErrorResponse(response.Error);

            return Ok(response);
        }
        private IActionResult ErrorResponse(ErrorModel model)
        {
            var httpCode = GetHttpStatusCode(model.Error);

            return StatusCode((int)httpCode,model);
        }
        private HttpStatusCode GetHttpStatusCode(string errorType) => errorType switch 
        {
            ErrorType.NotFound => HttpStatusCode.NotFound,
            ErrorType.Unauthorized => HttpStatusCode.Forbidden,
            ErrorType.NotAuthenticated => HttpStatusCode.Unauthorized,
            ErrorType.RequestTooLarge => HttpStatusCode.RequestEntityTooLarge,
            ErrorType.unsupportedMediaType => HttpStatusCode.UnsupportedMediaType,
            ErrorType.UnsuportedMethod => HttpStatusCode.MethodNotAllowed,
            ErrorType.TooManyRequests => HttpStatusCode.TooManyRequests,
            _=> HttpStatusCode.BadRequest
        };  
    }
}
