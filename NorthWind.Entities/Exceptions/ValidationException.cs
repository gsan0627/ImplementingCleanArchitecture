using NorthWind.Entities.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NorthWind.Entities.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<ValidationFailure> Errors { get; }
        public ValidationException() { }
        public ValidationException(string message) : base(message) { }
        public ValidationException(string message, Exception inneException)
            : base(message, inneException) { }
        public ValidationException(IEnumerable<ValidationFailure> errors)
        => Errors = errors;
    }
}