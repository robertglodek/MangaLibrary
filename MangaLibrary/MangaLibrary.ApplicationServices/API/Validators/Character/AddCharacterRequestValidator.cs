using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Creator;
using MangaLibrary.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.Character
{
    public class AddCharacterRequestValidator : AbstractValidator<AddCharacterRequest>
    {
        public AddCharacterRequestValidator(MangaLibraryDbContext context)
        {
            RuleFor(n => n.Name).NotEmpty().MaximumLength(100);
            RuleFor(n => n.Image).NotEmpty().MaximumLength(200);
            RuleFor(n => n.About).NotEmpty().MaximumLength(500);
            RuleFor(n => n.Name).Custom((value, validationContext) =>
            {
                var nameInUse = context.Characters.Any(n => n.Name == value);
                if (nameInUse)
                    validationContext.AddFailure("Name", "That name is already taken");

            });
        }
    }
}
