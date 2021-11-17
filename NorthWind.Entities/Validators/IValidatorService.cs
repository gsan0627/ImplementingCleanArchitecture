using NorthWind.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Entities.Validators
{
    public interface IValidatorService<T>
    {
        void Validate(T instance, IEnumerable<IValidator<T>> validators,
            IApplicationStatusLogger logger);
    }
}
