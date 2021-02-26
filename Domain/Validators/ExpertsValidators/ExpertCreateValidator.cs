using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.ExpertDTOs;
using FluentValidation;

namespace Domain.Validators.ExpertsValidators
{
    public class ExpertCreateValidator : AbstractValidator<ExpertDTOCreate>
    {
        public ExpertCreateValidator()
        {
            RuleFor(u => u.Name).NotNull().NotEqual("foo").NotEmpty().MaximumLength(50);
            RuleFor(u => u.Email).NotNull().NotEqual("foo").NotEmpty().EmailAddress().MaximumLength(50);
            RuleFor(u => u.Password).NotNull().NotEqual("foo").NotEmpty().MaximumLength(50);
            RuleFor(u => u.Avatar).NotEqual("foo").MaximumLength(500);
            RuleFor(u => u.Location).NotNull().NotEmpty().NotEqual("foo").MaximumLength(100);
        }
    }
}
