using System;
using FluentValidation;
using Popip.Infrastructure.Dtos;

namespace Popip.Infrastructure.Validators
{
    public class ItemValidator : AbstractValidator<ItemDto>
    {
        public ItemValidator()
        {
            RuleFor(item => item.Name).NotEmpty().WithMessage("This field is required");
            RuleFor(item => item.Description)
                .MaximumLength(200).WithMessage("This field just accept 200 characters as maximun");
        }
    }
}
