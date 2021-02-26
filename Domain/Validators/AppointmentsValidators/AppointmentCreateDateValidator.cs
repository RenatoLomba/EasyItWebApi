using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.AppointmentDTOs;
using FluentValidation;

namespace Domain.Validators.AppointmentsValidators
{
    public class AppointmentCreateDateValidator : AbstractValidator<AppointmentDTOCreateDateDTO>
    {
        public AppointmentCreateDateValidator()
        {
            RuleFor(u => u.Day).NotNull();
            RuleFor(u => u.Month).NotNull();
            RuleFor(u => u.Year).NotNull();
            RuleFor(u => u.Hour).NotNull();
            RuleFor(u => u.Minutes).NotNull();
            RuleFor(u => u.AvailableHourId).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
