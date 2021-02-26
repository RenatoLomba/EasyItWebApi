using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.UserDTOs;
using FluentValidation;

namespace Domain.Validators.UsersValidators
{
    public class UserUpdateValidator : AbstractValidator<UserDTOUpdate>
    {
        public UserUpdateValidator()
        {
            RuleFor(u => u.Id).NotNull().NotEmpty().NotEqual(Guid.Empty);
            RuleFor(u => u.Name).NotEqual("foo").MaximumLength(50);
            RuleFor(u => u.Email).NotEqual("foo").EmailAddress().MaximumLength(50);
            RuleFor(u => u.Password).NotEqual("foo").MaximumLength(50);
            RuleFor(u => u.Avatar).NotEqual("foo").MaximumLength(500);
        }
    }
}
