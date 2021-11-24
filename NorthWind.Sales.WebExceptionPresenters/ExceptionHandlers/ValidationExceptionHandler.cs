using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.WebExceptionPresenters.ExceptionHandlers
{
    class ValidationExceptionHandler : IExceptionHandler<ValidationException>
    {
        public Task<ProblemDetails> Handle(ValidationException exception)
        {
            ProblemDetails problemDetail = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = "Error en los datos de entradas",
                Detail = "Se encontró uno o más errores de validación de datos"
            };

            Dictionary<string, string> extensions = new Dictionary<string, string>();
            foreach (var failure in exception.Errors)
            {
                if(extensions.ContainsKey(failure.PropertyName))
                {
                    extensions[failure.PropertyName] += " " + failure.ErrorMessage;
                }
                else
                {
                    extensions.Add(failure.PropertyName, failure.ErrorMessage);
                }
            }                

            problemDetail.Extensions.Add("invalid-params", extensions);
            return Task.FromResult(problemDetail);
        }
    }
}
