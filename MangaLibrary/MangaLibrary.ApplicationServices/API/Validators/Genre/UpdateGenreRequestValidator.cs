using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Genre;
using MangaLibrary.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.Genre
{
    public class UpdateGenreRequestValidator:AbstractValidator<UpdateGenreRequest>
    {
        public UpdateGenreRequestValidator(MangaLibraryDbContext context)
        {
            RuleFor(n => n.Name).NotEmpty().MaximumLength(100);
            RuleFor(n => new { n.Name, n.Id }).Custom((value, validationContext) =>
            {
                var nameInUse = context.Genres.Any(n => n.Name == value.Name && n.Id != value.Id);
                if (nameInUse)
                    validationContext.AddFailure("Name", "That name is already taken");
            });
        }
    }
}
