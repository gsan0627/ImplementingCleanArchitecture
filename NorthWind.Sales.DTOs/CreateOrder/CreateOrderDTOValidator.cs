using FluentValidation;
using NorthWind.Entities.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthWind.Sales.DTOs.CreateOrder
{
    public class CreateOrderDTOValidator : 
        AbstractValidator<CreateOrderDTO>,
        Entities.Validators.IValidator<CreateOrderDTO>
    {
        public CreateOrderDTOValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty()
                .WithMessage("Debe proporcinar el identificador de cliente")
                .Length(5)
                .WithMessage("La longitud del identificador debe ser 5");

            RuleFor(x => x.ShipAddress).NotEmpty()
               .WithMessage("Debe proporcinar la dirección de envío")
               .MaximumLength(60)
               .WithMessage("La longitud máxima de la dirección es 60");

            RuleFor(x => x.ShipCity).NotEmpty()
               .WithMessage("Debe proporcinar la ciudad de envío")
               .MaximumLength(15)
               .WithMessage("La longitud máxima de la ciudad es 15")
               .MinimumLength(3)
               .WithMessage("Debe especificar al menos 3 caracteres");

            RuleFor(x => x.ShipCountry).NotEmpty()
               .WithMessage("Debe proporcinar el pais de envío")
               .MaximumLength(15)
               .WithMessage("La longitud máxima de la pais es 15")
               .MinimumLength(3)
               .WithMessage("Debe especificar al menos 3 caracteres");

            RuleFor(x => x.ShipPostalCode)
               .MaximumLength(10)
               .WithMessage("La longitud máxima de la pais es 10");

            RuleFor(x => x.OrderDetails)
               .NotNull()
               .WithMessage("Debe especificar los productos de la orden")
               .NotEmpty()
               .WithMessage("Debe especificar al menos un producto de la orden");

            RuleForEach(e => e.OrderDetails)
                .SetValidator(new CreateOrderDetailDTOValidator());

        }

        ValidationResult Entities.Validators.IValidator<CreateOrderDTO>.Validate(CreateOrderDTO instance)
        {
            var result = Validate(instance);
            return new ValidationResult(
                result.Errors?
                .Select(e =>
                    new ValidationFailure(e.PropertyName, e.ErrorMessage)));
        }
    }
}
