using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebAPI.Models
{
    using System;
    using System.Net;

    public class ServerErrorException : Exception
    {
        public ServerErrorException()
            : base()
        {
        }

        public ServerErrorException(string msg)
            : base(msg)
        {
            this.StatusCode = HttpStatusCode.InternalServerError;
        }

        public ServerErrorException(string msg, HttpStatusCode statusCode)
            : base(msg)
        {
            this.StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}