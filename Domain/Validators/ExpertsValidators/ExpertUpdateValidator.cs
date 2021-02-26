using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.ExpertDTOs;
using FluentValidation;

namespace Domain.Validators.ExpertsValidators
{
    public class ExpertUpdateValidator : AbstractValidator<ExpertDTOUpdate>
    {
        public ExpertUpdateValidator()
        {
            RuleFor(u => u.Id).NotNull().NotEmpty().NotEqual(Guid.Empty);
            RuleFor(u => u.Name).NotEqual("foo").MaximumLength(50);
            RuleFor(u => u.Email).NotEqual("foo").EmailAddress().MaximumLength(50);
            RuleFor(u => u.Password).NotEqual("foo").MaximumLength(50);
            RuleFor(u => u.Avatar).NotEqual("foo").MaximumLength(500);
            RuleFor(u => u.Location).NotEqual("foo").MaximumLength(100);
        }
    }
}

