using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.WebExceptionPresenters.ExceptionHandlers
{
    interface IExceptionHandler<ExceptionType>
    {
        Task<ProblemDetails> Handle(ExceptionType exception);
    }
}