using MangaLibrary.DataAccess.CQRS.Models;
using MangaLibrary.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Queries.Volume
{
    public class GetVolumesQuery : QueryBase<PagedResult<MangaLibrary.DataAccess.Entities.Volume>>
    {
        public string SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }

        public async override Task<PagedResult<MangaLibrary.DataAccess.Entities.Volume>> Execute(MangaLibraryDbContext context)
        {
            var baseQuery = context
                .Volumes
                .Where(n => SearchPhrase == null ||
                (n.Arc.ToLower().Contains(SearchPhrase.ToLower())) ||
                (n.Name.ToLower().Contains(SearchPhrase.ToLower())) ||
                (n.Description.ToLower().Contains(SearchPhrase.ToLower())));


            if (!string.IsNullOrEmpty(SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<MangaLibrary.DataAccess.Entities.Volume, object>>>
                {
                    { nameof(MangaLibrary.DataAccess.Entities.Volume.Name), n => n.Name },
                    { nameof(MangaLibrary.DataAccess.Entities.Volume.Arc), n => n.Arc },
                    { nameof(MangaLibrary.DataAccess.Entities.Volume.ReleaseDate), n => n.ReleaseDate},
                };

                var selectedColumn = columnsSelectors[SortBy];

                baseQuery = SortDirection == SortDirection.Ascending
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }
            var volume = await baseQuery
                .Skip(PageSize * (PageNumber - 1))
                .Take(PageSize)
                .ToListAsync();
            var totalItemsCount = baseQuery.Count();
            return new PagedResult<Entities.Volume>(volume, totalItemsCount, PageSize, PageNumber);
        }
    }
}
