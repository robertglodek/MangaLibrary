using MangaLibrary.ApplicationServices.API.Domain;
using MangaLibrary.ApplicationServices.API.ErrorHandling;
using MangaLibrary.UI.ApiModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace MangaLibrary.UI.Controllers
{
    
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ApiControllerBase> _logger;

        public ApiControllerBase(IMediator mediator,ILogger<ApiControllerBase> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        protected async Task<IActionResult> HandleRequest<TRequest,TResponse>(TRequest request)
            where TRequest : IRequest<TResponse> 
            where TResponse: ErrorResponseBase
        {
            

            if (!this.ModelState.IsValid)
            {   
                IEnumerable<Error> errors= this.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new Error() { Property = x.Key, Errors = x.Value.Errors.Select(n => n.ErrorMessage) });

                return this.BadRequest(errors);
            }

            var response = await _mediator.Send(request);

            if(response.Error != null)
            {
                _logger.LogInformation(response.Error.ToString());
                return ErrorResponse(response.Error);
            }

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
        
        public void ReValidateModel(object model)
        {
            ModelState.Clear();
            TryValidateModel(model);
        }
    }
}
