using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Volume;
using MangaLibrary.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.Volume
{

    public class UpdateVolumeReqeustValidator : AbstractValidator<UpdateVolumeRequest>
    {

        public UpdateVolumeReqeustValidator(MangaLibraryDbContext context)
        {
            RuleFor(n => n.Name).NotEmpty().MaximumLength(100);
            RuleFor(n => n.Name).Custom((value, validationContext) =>
            {
                var nameInUse = context.Volumes.Any(n => n.Name == value);
                if (nameInUse)
                    validationContext.AddFailure("Name", "That name is already taken");

            });
            RuleFor(n => n.Description).NotEmpty().MaximumLength(500);
            RuleFor(n => n.Arc).NotEmpty().MaximumLength(50);
        }
    }
}
