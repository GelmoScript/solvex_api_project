using System;
using FluentValidation;
using Popip.Infrastructure.Dtos;

namespace Popip.Infrastructure.Validators
{
    public class ItemValidator : AbstractValidator<ItemDto>
    {
        public ItemValidator()
        {
            RuleFor(item => item.Name).NotEmpty().WithMessage("The name field is required")
                .MaximumLength(10).WithMessage("The name field has a maximum size of 10");
            RuleFor(item => item.Description)
                .MaximumLength(200).WithMessage("This field just accept 200 characters as maximun");
        }
    }
}
