using System.Net;

namespace Adochat.Domain.Exceptions
{
    [Serializable]
    public class HttpException: ApplicationException
    {
        public HttpStatusCode StatusCode { get; set; }
        public HttpException() { }

        public HttpException(HttpStatusCode statusCode, string message) : base(message)
        {
            this.StatusCode = statusCode;
        }

        public HttpException(string message, Exception inner) : base(message, inner) { }

        protected HttpException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
