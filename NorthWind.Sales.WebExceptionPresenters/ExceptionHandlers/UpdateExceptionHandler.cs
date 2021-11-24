using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.WebExceptionPresenters.ExceptionHandlers
{
    class UpdateExceptionHandler : IExceptionHandler<UpdateException>
    {
        public Task<ProblemDetails> Handle(UpdateException exception)
        {
            ProblemDetails problemDetail = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "Error de actualización",        
                Detail = exception.Message,
            };

            Dictionary<string, string> extensions =
                new Dictionary<string, string>()
                {
                    {"entities", string.Join(",", exception.Entries) }
                };

            problemDetail.Extensions.Add("invalid-params", extensions);
            return Task.FromResult(problemDetail);
        }
    }
}
