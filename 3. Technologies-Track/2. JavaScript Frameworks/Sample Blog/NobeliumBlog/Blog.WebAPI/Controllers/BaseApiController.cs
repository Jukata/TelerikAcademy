namespace Blog.WebAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Blog.WebAPI.Models;

    public class BaseApiController : ApiController
    {
        protected const string ValidSessionKeyChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM0123456789";
        protected const string SessionKeyPostfixChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
        protected const int SessionKeyLen = 50;

        public BaseApiController()
        {
        }

        // Void Operations
        protected HttpResponseMessage PerformOperation(Action action)
        {
            try
            {
                action();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (ServerErrorException ex)
            {
                return BuildErrorResponse(ex.Message, ex.StatusCode);
            }
            catch (Exception ex)
            {
                return BuildErrorResponse(
                    "General Server Error",
                    HttpStatusCode.InternalServerError);
            }
        }

        // Return Operations
        protected HttpResponseMessage PerformOperation<T>(Func<T> action)
        {
            try
            {
                var result = action();

                if (result is HttpResponseMessage)
                {
                    return result as HttpResponseMessage;
                }

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (ServerErrorException ex)
            {
                return BuildErrorResponse(ex.Message, ex.StatusCode);
            }
            catch (Exception ex)
            {
                return BuildErrorResponse(
                    "General Server Error",
                    HttpStatusCode.InternalServerError);
            }
        }

        // Common Validation
        protected void ValidateSessionKey(string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new ServerErrorException(
                    "Invalid session key",
                    HttpStatusCode.BadRequest);
            }

            if (sessionKey.Length != SessionKeyLen)
            {
                throw new ServerErrorException
                    ("Invalid session key length",
                    HttpStatusCode.BadRequest);
            }

            if (sessionKey.Any(ch => !ValidSessionKeyChars.Contains(ch)))
            {
                throw new ServerErrorException(
                    "Session key contains invalid characters",
                    HttpStatusCode.BadRequest);
            }
        }

        private HttpResponseMessage BuildErrorResponse(string message, HttpStatusCode statusCode)
        {
            var httpError = new HttpError(message);
            return Request.CreateErrorResponse(statusCode, httpError);
        }
    }
}
