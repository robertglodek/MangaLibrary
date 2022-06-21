using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Volume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.Volume
{
    public class DeleteVolumeRequestValidator : AbstractValidator<DeleteVolumeRequest>
    {
        public DeleteVolumeRequestValidator()
        {
            RuleFor(n => n.Id).NotEmpty();
        }
    }
}
