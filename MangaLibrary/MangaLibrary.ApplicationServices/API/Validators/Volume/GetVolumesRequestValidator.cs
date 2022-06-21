using FluentValidation;
using MangaLibrary.ApplicationServices.API.Domain.Volume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Validators.Volume
{
    public class GetVolumesRequestValidator : AbstractValidator<GetVolumesRequest>
    {
        private int[] allowedPageSizes = new[] { 6, 12, 18 };

        private string[] allowedSortByColumnNames = new[]
            { nameof(MangaLibrary.DataAccess.Entities.Volume.Name),
              nameof(MangaLibrary.DataAccess.Entities.Volume.Arc),
              nameof(MangaLibrary.DataAccess.Entities.Volume.ReleaseDate)};

        public GetVolumesRequestValidator()
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
