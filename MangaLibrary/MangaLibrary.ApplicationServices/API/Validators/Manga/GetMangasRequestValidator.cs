using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Manga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.Manga
{

    public class GetMangasRequestValidator : AbstractValidator<GetMangasRequest>
    {
        private int[] allowedPageSizes = new[] { 6, 12, 18 };

        private string[] allowedSortByColumnNames = new[]
            { nameof(MangaLibrary.DataAccess.Entities.Creator.FirstName),
              nameof(MangaLibrary.DataAccess.Entities.Creator.LastName),
              nameof(MangaLibrary.DataAccess.Entities.Creator.DateOfBirth)};

        public GetMangasRequestValidator()
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
