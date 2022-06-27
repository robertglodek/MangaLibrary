using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.User;
using MangaLibrary.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.User
{
    public class RegisterUserRequestValidator:AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator(MangaLibraryDbContext context)
        {
            RuleFor(n => n.Email).NotEmpty().EmailAddress().Custom((value, validationContext) =>
            {
                var emailInUse = context.Users.Any(n => n.Email == value);
                if (emailInUse)
                    validationContext.AddFailure("Email", "That email is taken");
            }).MaximumLength(100);
           
            RuleFor(n => n.Password).NotEmpty().MinimumLength(8).MaximumLength(50).Matches("\\d{2,}").WithMessage("Password must contain at least two digits");
            RuleFor(n => n.ConfirmPassword).Equal(n =>n.Password);
            RuleFor(n => n.Nationality).NotEmpty().MaximumLength(40);
            RuleFor(n => n.FirstName).NotEmpty().MaximumLength(40);
            RuleFor(n => n.LastName).NotEmpty().MaximumLength(40);
        }
    }
}
