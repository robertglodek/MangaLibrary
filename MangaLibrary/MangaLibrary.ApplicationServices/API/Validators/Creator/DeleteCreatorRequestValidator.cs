using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Creator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.Creator
{
    public class DeleteCreatorRequestValidator : AbstractValidator<DeleteCreatorRequest>
    {
        public DeleteCreatorRequestValidator()
        {
            RuleFor(n => n.Id).NotEmpty();
        }
    }
}
