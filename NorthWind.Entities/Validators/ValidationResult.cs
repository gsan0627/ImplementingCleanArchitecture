using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthWind.Entities.Validators
{
    public class ValidationResult
    {
        public IEnumerable<ValidationFailure> Errors { get; }
        public ValidationResult(IEnumerable<ValidationFailure> errors)
            => Errors = errors;

        public bool IsValid =>
            !Errors.Any() || Errors == null;

    }
}
