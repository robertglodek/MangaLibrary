using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Manga;
using MangaLibrary.DataAccess.Data;
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

        private string[] allowedGenres;
        private string[] allowedDemographics;

        public GetMangasRequestValidator(MangaLibraryDbContext mangaLibraryDbContext)
        {
            allowedGenres = mangaLibraryDbContext.Genres.Select(n => n.Name).ToArray();
            allowedDemographics = mangaLibraryDbContext.Demographics.Select(n => n.Value).ToArray();

            RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(r => r.PageSize).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                    context.AddFailure("PageSize", $"PageSize must in [{string.Join(",", allowedPageSizes)}]");
            });
            RuleFor(r => r.SortBy)
                .Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");

            RuleFor(r => r.Demographic)
                .Must(value => string.IsNullOrEmpty(value) || allowedDemographics.Contains(value))
                .WithMessage($"Demographic is optional, or must be in [{string.Join(",", allowedDemographics)}]");

            RuleFor(r => r.Genre)
               .Must(value => string.IsNullOrEmpty(value) || allowedGenres.Contains(value))
               .WithMessage($"Genre by is optional, or must be in [{string.Join(",", allowedGenres)}]");
        }
    }
}
