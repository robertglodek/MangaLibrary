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
    public class UpdatePasswordRequestValidator : AbstractValidator<UpdatePasswordRequest>
    {
        public UpdatePasswordRequestValidator()
        {
            RuleFor(n => n.OldPassword).NotEmpty().MinimumLength(8).MaximumLength(50);
            RuleFor(n => n.NewPassword).NotEmpty().MinimumLength(8).MaximumLength(50).Matches("\\d{2,}").WithMessage("Password must contain at least two digits");
            RuleFor(n => n.ConfirmNewPassword).Equal(n => n.NewPassword);
        }
    }
}
