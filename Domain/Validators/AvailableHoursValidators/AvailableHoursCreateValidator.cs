using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.AvailableHourDTOs;
using FluentValidation;

namespace Domain.Validators.AvailableHoursValidators
{
    public class AvailableHoursCreateValidator : AbstractValidator<AvailableHourDTOCreate>
    {
        public AvailableHoursCreateValidator()
        {
            RuleFor(u => u.Hour).NotNull();
            RuleFor(u => u.Minutes).NotNull();
        }
    }
}
