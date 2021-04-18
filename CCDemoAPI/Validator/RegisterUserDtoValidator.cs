using CCDemoAPI.Entities;
using CCDemoAPI.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCDemoAPI.Validator
{
    public class RegisterUserDtoValidator: AbstractValidator<RegisterUserDto>
    {

        public RegisterUserDtoValidator(CCDbContext dbContext)
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).MinimumLength(6);
            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var emailExists = dbContext.Users.Any(u => u.Email == value);
                if (emailExists)
                {
                    context.AddFailure("Email", "That email already exists");
                }
            });
        }
    }
}
