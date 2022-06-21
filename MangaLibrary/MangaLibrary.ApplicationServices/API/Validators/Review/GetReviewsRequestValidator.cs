using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.Review
{

    public class GetReviewsRequestValidator : AbstractValidator<GetReviewsRequest>
    {
        private int[] allowedPageSizes = new[] { 6, 12, 18 };

        private string[] allowedSortByColumnNames = new[]
            { nameof(MangaLibrary.DataAccess.Entities.Review.PublishDate),
              nameof(MangaLibrary.DataAccess.Entities.Review.Rating)};

        public GetReviewsRequestValidator()
        {
            RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(r => r.PageSize).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                    context.AddFailure("PageSize", $"PageSize must in [{string.Join(",", allowedPageSizes)}]");
            });
            RuleFor(r => r.SortBy)
                .Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
        }
    }
}
