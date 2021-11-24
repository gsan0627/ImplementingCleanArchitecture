using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.WebExceptionPresenters.ExceptionHandlers
{
    class GeneralExceptionHandler : IExceptionHandler<GeneralException>
    {
        public Task<ProblemDetails> Handle(GeneralException exception)
        {
            ProblemDetails problemDetail = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                Title = exception.Message,
                Detail = exception.Detail
            };

            return Task.FromResult(problemDetail);
        }
    }
}
