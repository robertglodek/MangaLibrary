using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Demographic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.Demographic
{
    public class DeleteDemographicRequestValidator:AbstractValidator<DeleteDemographicRequest>
    {

        public DeleteDemographicRequestValidator()
        {
            RuleFor(n => n.Id).NotEmpty();
        }
    }
}
