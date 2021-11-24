using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Sales.BlazorClient.Exceptions
{
    public class ProblemDetails
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; }
        public  IDictionary<string, string> InvalidParams { get; set; }
    }

}
