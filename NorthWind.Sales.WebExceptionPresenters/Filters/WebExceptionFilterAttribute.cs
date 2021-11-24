using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NorthWind.Sales.WebExceptionPresenters.ExceptionHandlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.WebExceptionPresenters.Filters
{
    public class WebExceptionFilterAttribute : ExceptionFilterAttribute 
    {
        readonly ExceptionService _service;
        public WebExceptionFilterAttribute(ExceptionService service)
            => _service = service;

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            var problemDetails = await _service.Handle(context.Exception);
            context.Result = new ObjectResult(problemDetails)
            {
                StatusCode = problemDetails.Status
            };

            context.ExceptionHandled = true;
            await base.OnExceptionAsync(context);
        }
    }
}
