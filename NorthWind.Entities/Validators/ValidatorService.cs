using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthWind.Entities.Validators
{
    public class ValidatorService<Model> : IValidatorService<Model>
    {    
        public void Validate(Model instance, IEnumerable<IValidator<Model>> validators, IApplicationStatusLogger logger)
        {
            var failures = validators
                .Select(x => x.Validate(instance))
                .SelectMany(r => r.Errors)
                .Where( f=> f != null)
                .ToList();

            if (failures.Count > 0)
            {
                if (logger != null)
                {
                    StringBuilder builder = new StringBuilder();
                    foreach (var failure in failures)
                    {
                        builder.AppendLine(
                            $"{failure.PropertyName}: {failure.ErrorMessage}");
                    }
                    logger.Log(builder.ToString());
                }
                throw new ValidationException(failures);
            }
        }
    }
}
