using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Sales.BlazorClient.Exceptions
{
    public class HttpCustomException : Exception
    {
        public ProblemDetails ProblemDetails { get; set; }
        public HttpCustomException() { }
        public HttpCustomException(string message) 
            : base(message) { }
        public HttpCustomException(string message, Exception innerException) 
            : base(message, innerException) { }
        public HttpCustomException(ProblemDetails problemDetails)
            : base(problemDetails.Title)
        {
            ProblemDetails = problemDetails;
        }
    }
}
