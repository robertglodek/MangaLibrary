﻿using FluentValidation;
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
            RuleFor(n => n.Name).NotEmpty().MaximumLength(100);
            RuleFor(n => n.Description).NotEmpty().MaximumLength(500);
            RuleFor(n => n.Story).NotEmpty().MaximumLength(500);
            RuleFor(n => n.Heroes).NotEmpty().MaximumLength(500);
            RuleFor(n => n.Status).NotEmpty().MaximumLength(40);
            RuleFor(n => n.DemographicId).NotEmpty();
            RuleFor(n => n.CreatorsIds).NotEmpty().Custom((values, validationContext) =>
            {
                if (values != null && values.Count() > 1 && values.Count() != values.Distinct().Count())
                    validationContext.AddFailure("CreatorsIds", "Entered duplicate values");

            });
            RuleFor(n => n.GenresIds).Custom((values, validationContext) =>
            {
                if (values != null && values.Count() > 1 && values.Count() != values.Distinct().Count())
                    validationContext.AddFailure("GenresIds", "Found duplicate values");

            });
            RuleFor(n => new { n.Name, n.Id } ).Custom((value, validationContext) =>
            {
                var nameInUse = context.Mangas.Any(n => n.Name == value.Name && n.Id!=value.Id  );
                if (nameInUse)
                    validationContext.AddFailure("Name", "That name is already taken");
            });
        }
    }
}
