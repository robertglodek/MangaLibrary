using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Creator;
using MangaLibrary.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.Creator
{
    public class AddCreatorRequestValidator:AbstractValidator<AddCreatorRequest>
    {
        public AddCreatorRequestValidator(MangaLibraryDbContext context)
        {

            RuleFor(n => n.FirstName).NotEmpty().MaximumLength(40);
            RuleFor(n => n.LastName).NotEmpty().MaximumLength(40);
            RuleFor(n => n.Nationality).NotEmpty().MaximumLength(40);
            RuleFor(n => n.Description).NotEmpty().MaximumLength(500);
           
        }

       
    }
}
