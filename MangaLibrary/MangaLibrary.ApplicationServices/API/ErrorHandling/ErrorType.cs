using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.ErrorHandling
{
    public static class ErrorType
    {
        public const string BadRequestError = "bad_request";

        public const string publicServerError = "intenal_server_error";

        public const string ValidationError = "validation_error";

        public const string NotAuthenticated = "not_authenticated";

        public const string Unauthorized = "unauthorized";

        public const string NotFound = "not_found";

        public const string unsupportedMediaType= "unsuported_media_type";

        public const string UnsuportedMethod = "unsuported_method";

        public const string RequestTooLarge = "request_too_large";

        public const string TooManyRequests = "too_many_requests";
    }
}
