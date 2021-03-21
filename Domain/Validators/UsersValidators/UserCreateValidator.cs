using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.UserDTOs;
using FluentValidation;

namespace Domain.Validators.UsersValidators
{
    public class UserCreateValidator : AbstractValidator<UserDTOCreate>
    {
        public UserCreateValidator()
        {
            RuleFor(u => u.Name).NotNull().NotEqual("foo").NotEmpty().MaximumLength(50);
            RuleFor(u => u.Email).NotNull().NotEqual("foo").NotEmpty().EmailAddress().MaximumLength(50);
            RuleFor(u => u.Password).NotNull().NotEqual("foo").NotEmpty().MaximumLength(200);
            RuleFor(u => u.Avatar).NotEqual("foo").MaximumLength(500);
        }
    }
}
