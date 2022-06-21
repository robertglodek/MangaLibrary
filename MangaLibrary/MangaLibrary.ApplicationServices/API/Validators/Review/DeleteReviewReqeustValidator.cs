using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.Review
{
 
    public class DeleteReviewReqeustValidator : AbstractValidator<DeleteReviewRequest>
    {
        public DeleteReviewReqeustValidator()
        {
            RuleFor(n => n.Id).NotEmpty();
        }
    }
}
