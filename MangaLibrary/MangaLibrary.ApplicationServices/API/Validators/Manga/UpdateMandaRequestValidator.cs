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
 

    public class UpdateMandaRequestValidator : AbstractValidator<UpdateMangaRequest>
    {

        public UpdateMandaRequestValidator(MangaLibraryDbContext context)
        {

            RuleFor(n => n.Id).NotEmpty();
            RuleFor(n => n.Name).NotEmpty().MaximumLength(100);
            RuleFor(n => n.Description).NotEmpty().MaximumLength(500);
            RuleFor(n => n.Story).NotEmpty().MaximumLength(40);
            RuleFor(n => n.Heroes).NotEmpty().MaximumLength(40);
            RuleFor(n => n.Status).NotEmpty().MaximumLength(40);
            RuleFor(n => n.DemographicId).Custom((value, validationContext) =>
            {
                var demographic = context.Demographics.Any(n => n.Id == value);
                if (!demographic)
                    validationContext.AddFailure("DemographicId", "Demographic doesn't exist");
            });
            RuleFor(n => n.CreatorsIds).Custom((values, validationContext) =>
            {
                if (values.Count() < 1)
                {
                    validationContext.AddFailure("CreatorsIds", "Manga must have at least one creator");
                }
                else
                {
                    var creators = context.Creators.Where(n => values.Contains(n.Id));
                    if (creators.Count() < values.Count())
                        validationContext.AddFailure("CreatorsIds", "Can't find some of provided creators");
                }

            });
            RuleFor(n => n.GenresIds).Custom((values, validationContext) =>
            {
                if (values.Count() < 1)
                {
                    validationContext.AddFailure("GenresIds", "Manga must have at least one genre");
                }
                else
                {
                    var genres = context.Genres.Where(n => values.Contains(n.Id));
                    if (genres.Count() < values.Count())
                        validationContext.AddFailure("GenresIds", "Can't find some of provided genres");
                }
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
