using System;
using System.Net;

namespace Letters.API.Exceptions
{
  public class HttpResponseException : Exception
  {
    public HttpStatusCode StatusCode { get; private set; }

    public HttpResponseException(HttpStatusCode statusCode, string message) : base(message)
    {
      StatusCode = statusCode;
    }
  }
}