using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.Genre
{
    public class DeleteGenreRequestValidator:AbstractValidator<DeleteGenreRequest>
    {
        public DeleteGenreRequestValidator()
        {
            RuleFor(n => n.Id).NotEmpty();
        }
    }
}
