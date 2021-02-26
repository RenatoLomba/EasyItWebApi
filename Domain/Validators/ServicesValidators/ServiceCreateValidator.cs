using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.ServiceDTOs;
using FluentValidation;

namespace Domain.Validators.ServicesValidators
{
    public class ServiceCreateValidator : AbstractValidator<ServiceDTOCreate>
    {
        public ServiceCreateValidator()
        {
            RuleFor(u => u.Name).NotNull().NotEqual("foo").NotEmpty().MaximumLength(60);
            RuleFor(u => u.Code).NotNull().NotEqual("foo").NotEmpty().MaximumLength(100);
            RuleFor(u => u.Description).NotNull().NotEqual("foo").NotEmpty().MaximumLength(200);
            RuleFor(u => u.ExpertId).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
