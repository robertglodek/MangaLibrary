using MangaLibrary.DataAccess.CQRS.Models;
using MangaLibrary.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Queries.Creator
{

    public class GetCreatorsQuery : QueryBase<Result<PagedResult<MangaLibrary.DataAccess.Entities.Creator>>>
    {
        public string SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }

        public async override Task<Result<PagedResult<MangaLibrary.DataAccess.Entities.Creator>>> Execute(MangaLibraryDbContext context)
        {
            var baseQuery = context
                .Creators
                .Include(n => n.Mangas)
                .Where(n => SearchPhrase == null ||
                (n.FirstName.ToLower().Contains(SearchPhrase.ToLower())) ||
                (n.LastName.ToLower().Contains(SearchPhrase.ToLower())));


            if (!string.IsNullOrEmpty(SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<MangaLibrary.DataAccess.Entities.Creator, object>>>
                {
                    { nameof(MangaLibrary.DataAccess.Entities.Creator.FirstName), n => n.FirstName },
                    { nameof(MangaLibrary.DataAccess.Entities.Creator.LastName), n => n.LastName },
                    { nameof(MangaLibrary.DataAccess.Entities.Creator.DateOfBirth), n => n.DateOfBirth}, 
                };

                var selectedColumn = columnsSelectors[SortBy];

                baseQuery = SortDirection == SortDirection.Ascending
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }
            var creators = await baseQuery
                .Skip(PageSize * (PageNumber - 1))
                .Take(PageSize)
                .ToListAsync();
            var totalItemsCount = baseQuery.Count();
            return Result<PagedResult<Entities.Creator>>.Success(new PagedResult<Entities.Creator>(creators, totalItemsCount, PageSize, PageNumber));
        }
    }
}
