using Microsoft.AspNetCore.Mvc;
using NorthWind.Sales.WebExceptionPresenters.ExceptionHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.WebExceptionPresenters.Filters
{
    public static class Filters
    {
        public static void Register(MvcOptions option)
        {
            option.Filters.Add(new WebExceptionFilterAttribute(
                new ExceptionService()));
        }
    }
}
