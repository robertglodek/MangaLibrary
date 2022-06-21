using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Review;
using MangaLibrary.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.Review
{
    public class AddReviewRequestValidator : AbstractValidator<AddReviewRequest>
    {
        public AddReviewRequestValidator()
        {
            RuleFor(n => n.Content).NotEmpty().MaximumLength(200);
            RuleFor(n => n.Rating).NotEmpty().InclusiveBetween(1,5); 
        }
    }
}
