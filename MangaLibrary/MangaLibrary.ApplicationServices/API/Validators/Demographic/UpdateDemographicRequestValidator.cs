using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Demographic;
using MangaLibrary.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.Demographic
{

    public class UpdateDemographicRequestValidator : AbstractValidator<UpdateDemographicRequest>
    {
        public UpdateDemographicRequestValidator(MangaLibraryDbContext context)
        {
            RuleFor(n => n.Value).NotEmpty().MaximumLength(50);
            RuleFor(n => n.Description).NotEmpty().MaximumLength(100);
            RuleFor(n => n.Value).Custom((value, validationContext) =>
            {
                var nameInUse = context.Demographics.Any(n => n.Value == value);
                if (nameInUse)
                    validationContext.AddFailure("Name", "That value is already taken");

            });
        }
    }
}
