using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.UserDTOs;
using FluentValidation;

namespace Domain.Validators.UsersValidators
{
    public class UserLoginValidator : AbstractValidator<UserDTOLogin>
    {
        public UserLoginValidator()
        {
            RuleFor(u => u.Email).NotNull().NotEqual("foo").NotEmpty().EmailAddress().MaximumLength(50);
            RuleFor(u => u.Password).NotNull().NotEqual("foo").NotEmpty().MaximumLength(50);
        }
    }
}
