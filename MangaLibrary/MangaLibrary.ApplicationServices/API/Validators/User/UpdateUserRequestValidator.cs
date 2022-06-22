using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.User
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(n => n.Nationality).NotEmpty();
            RuleFor(n => n.FirstName).NotEmpty().MaximumLength(40);
            RuleFor(n => n.LastName).NotEmpty().MaximumLength(40);
        }
    }
}
