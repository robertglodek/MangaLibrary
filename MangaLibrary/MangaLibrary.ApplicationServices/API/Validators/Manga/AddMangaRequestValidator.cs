using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Manga;
using MangaLibrary.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.Manga
{
    public class AddMangaRequestValidator:AbstractValidator<AddMangaRequest>
    {
        public AddMangaRequestValidator(MangaLibraryDbContext context)
        {

            RuleFor(n => n.Name).NotEmpty().MaximumLength(100);
            RuleFor(n => n.Description).NotEmpty().MaximumLength(500);
            RuleFor(n => n.Story).NotEmpty().MaximumLength(40);
            RuleFor(n => n.Heroes).NotEmpty().MaximumLength(40);
            RuleFor(n => n.Status).NotEmpty().MaximumLength(40);
            RuleFor(n => n.CreatorsIds).Custom((values, validationContext) =>
            {
                if(values.Count()<1)
                    validationContext.AddFailure("CreatorsIds", "Manga must have at least one creator");
            });
            RuleFor(n => n.GenresIds).Custom((values, validationContext) =>
            {
                if (values.Count() < 1)
                    validationContext.AddFailure("GenresIds", "Manga must have at least one genre");
                 
            });
            RuleFor(n => n.Name).Custom((value, validationContext) =>
            {
                var nameInUse = context.Mangas.Any(n => n.Name == value);
                if (nameInUse)
                    validationContext.AddFailure("Name", "That name is already taken");
            });

        }
    }

}
