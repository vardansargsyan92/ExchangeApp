using System;
using System.Net;

namespace ExchangeApp.Core.Api.Implementation
{
    public class WebRequestException : Exception
    {
        public WebRequestException(HttpStatusCode responseStatusCode)
        {
            ResponseStatusCode = responseStatusCode;
        }

        public HttpStatusCode ResponseStatusCode { get; }

        public override string ToString()
        {
            return ResponseStatusCode.ToString();
        }
    }
}