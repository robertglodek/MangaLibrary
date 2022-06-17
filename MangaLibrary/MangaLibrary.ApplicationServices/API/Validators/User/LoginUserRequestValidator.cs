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
            RuleFor(n => n.Email).NotEmpty().EmailAddress();
            RuleFor(n=>n.Password).NotEmpty();
        }
    }
}
