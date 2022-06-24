using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.User
{
    public class LoginUserRequestValidator:AbstractValidator<LoginUserRequest>
    {
        public LoginUserRequestValidator()
        {
            RuleFor(n => n.Email).NotEmpty().MaximumLength(100);
            RuleFor(n=>n.Password).NotEmpty().MinimumLength(6).MaximumLength(50);
           
        }
    }
}
