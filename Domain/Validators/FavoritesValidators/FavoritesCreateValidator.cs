using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs.FavoritesDTOs;
using FluentValidation;

namespace Domain.Validators.FavoritesValidators
{
    public class FavoritesCreateValidator : AbstractValidator<FavoritesDTOCreate>
    {
        public FavoritesCreateValidator()
        {
            RuleFor(u => u.UserId).NotNull().NotEmpty().NotEqual(Guid.Empty);
            RuleFor(u => u.ExpertId).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
