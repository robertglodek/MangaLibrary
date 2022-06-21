using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Manga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.Manga
{
    public class DeleteMangaRequestValidator : AbstractValidator<DeleteMangaRequest>
    {
        public DeleteMangaRequestValidator()
        {
            RuleFor(n => n.Id).NotEmpty();
        }
    }
}
