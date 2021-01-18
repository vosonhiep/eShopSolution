using eShopSolution.ViewModels.System.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.BeckendApi.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("User name is required").MinimumLength(6).WithMessage("Password is at least 6 charactrers");
        }
    }
}
