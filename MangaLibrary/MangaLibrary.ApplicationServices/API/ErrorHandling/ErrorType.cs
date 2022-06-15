using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.ErrorHandling
{
    public static class ErrorType
    {
        public const string InternalServerError = "Intenal_server_error";

        public const string ValidationError = "Validation_error";

        public const string NotAuthenticated = "Not_authenticated";

        public const string Unauthorized = "Unauthorized";

        public const string NotFound = "Not_found";

        public const string unsupportedMediaType= "Unsuported_media_type";

        public const string UnsuportedMethod = "Unsuported_method";

        public const string RequestTooLarge = "Request_too_large";

        public const string TooManyRequests = "Too_many_requests";


    }
}
