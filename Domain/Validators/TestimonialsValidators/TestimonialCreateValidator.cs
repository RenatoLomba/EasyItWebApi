using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.TestimonialDTOs;
using FluentValidation;

namespace Domain.Validators.TestimonialsValidators
{
    public class TestimonialCreateValidator : AbstractValidator<TestimonialDTOCreate>
    {
        public TestimonialCreateValidator()
        {
            RuleFor(u => u.Description).NotNull().NotEqual("foo").NotEmpty().MaximumLength(60);
            RuleFor(u => u.Stars).NotNull();
            RuleFor(u => u.ExpertId).NotNull().NotEmpty().NotEqual(Guid.Empty);
            RuleFor(u => u.UserId).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
