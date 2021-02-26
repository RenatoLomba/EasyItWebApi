using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.PhotoDTOs;
using FluentValidation;

namespace Domain.Validators.PhotoValidators
{
    public class PhotoCreateValidator : AbstractValidator<PhotoDTOCreate>
    {
        public PhotoCreateValidator()
        {
            RuleFor(u => u.Name).NotNull().NotEqual("foo").NotEmpty().MaximumLength(60);
            RuleFor(u => u.Url).NotNull().NotEqual("foo").NotEmpty().MaximumLength(225);
            RuleFor(u => u.ExpertId).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
