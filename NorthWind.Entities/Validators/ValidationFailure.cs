using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Entities.Validators
{
    public class ValidationFailure
    {
        public string PropertyName { get; }
        public string ErrorMessage { get; set; }
        public ValidationFailure(string propertyName, string errorMessage)
            => (PropertyName, ErrorMessage) = (propertyName, errorMessage);
    }
}
