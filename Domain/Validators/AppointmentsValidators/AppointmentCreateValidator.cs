using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.AppointmentDTOs;
using FluentValidation;

namespace Domain.Validators.AppointmentsValidators
{
    public class AppointmentCreateValidator : AbstractValidator<AppointmentDTOCreate>
    {
        public AppointmentCreateValidator()
        {
            RuleFor(u => u.DateInfo).NotNull();
            RuleFor(u => u.ExpertId).NotNull().NotEmpty().NotEqual(Guid.Empty);
            RuleFor(u => u.UserId).NotNull().NotEmpty().NotEqual(Guid.Empty);
            RuleFor(u => u.ServiceId).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
