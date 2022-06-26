using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.Character
{
    public class UpdateCharacterRequestValidator : AbstractValidator<UpdateCharacterRequest>
    {
        public UpdateCharacterRequestValidator()
        {
            RuleFor(n => n.Name).NotEmpty().MaximumLength(100);
            RuleFor(n => n.Image).NotEmpty().MaximumLength(200);
            RuleFor(n => n.About).NotEmpty().MaximumLength(500);
        }
    }
}
