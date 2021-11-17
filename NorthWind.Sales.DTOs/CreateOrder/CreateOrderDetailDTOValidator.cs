using FluentValidation;
using NorthWind.Entities.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthWind.Sales.DTOs.CreateOrder
{
    public class CreateOrderDetailDTOValidator :
        AbstractValidator<CreateOrderDetailDTO>,
        Entities.Validators.IValidator<CreateOrderDetailDTO>
    {

        public CreateOrderDetailDtoValidator()
        {
            RuleFor(d => d.ProductId).GreaterThan(0)
                .WithMessage("Debe especificar el identificador del producto");
            RuleFor(d => d.Quantity).GreaterThan((short)0)
                .WithMessage("Debe especificar la cantidad ordenada del producto");
            RuleFor(d => d.UnitPrice).GreaterThan(0)
                .WithMessage("Debe especficar el identificador del producto");
        }

        ValidationResult Entities.Validators.IValidator<CreateOrderDetailDTO>.Validate(
            CreateOrderDetailDTO instance)
        {
            var result = Validate(instance);
            return new ValidationResult(
                result.Errors?
                .Select(e =>
                    new ValidationFailure(e.PropertyName, e.ErrorMessage)));
        }
    }
}