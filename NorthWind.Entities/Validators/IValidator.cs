using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Entities.Validators
{
    public interface IValidator<T>
    {
        ValidationResult Validate(T instance);
    }
}
