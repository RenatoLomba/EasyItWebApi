using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.AvailableDateDTOs;
using FluentValidation;

namespace Domain.Validators.AvailableDatesValidators
{
    public class AvailableDateCreateValidator : AbstractValidator<AvailableDateDTOCreate>
    {
        public AvailableDateCreateValidator()
        {
            RuleFor(u => u.ExpertId).NotNull();
            RuleFor(u => u.Day).NotNull().NotEqual(0);
            RuleFor(u => u.Month).NotNull().NotEqual(0);
            RuleFor(u => u.Year).NotNull().NotEqual(0);
            RuleFor(u => u.AvailableHours).NotNull().NotEmpty();
        }
    }
}
