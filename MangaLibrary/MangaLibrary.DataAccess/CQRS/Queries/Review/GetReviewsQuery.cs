using MangaLibrary.DataAccess.CQRS.Models;
using MangaLibrary.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Queries.Review
{
   
    public class GetReviewsQuery : QueryBase<PagedResult<MangaLibrary.DataAccess.Entities.Review>>
    {
        public Guid MangaId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }

        public async override Task<PagedResult<MangaLibrary.DataAccess.Entities.Review>> Execute(MangaLibraryDbContext context)
        {
            IQueryable<Entities.Review> baseQuery = context
                .Reviews
                .Include(n => n.Author).Where(n=>n.MangaId==MangaId);
                

            if (!string.IsNullOrEmpty(SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<MangaLibrary.DataAccess.Entities.Review, object>>>
                {
                    { nameof(MangaLibrary.DataAccess.Entities.Review.PublishDate), n => n.PublishDate },
                    { nameof(MangaLibrary.DataAccess.Entities.Review.Rating), n => n.Rating },
                };
                var selectedColumn = columnsSelectors[SortBy];
                baseQuery = SortDirection == SortDirection.Ascending
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }
            var reviews = await baseQuery
                .Skip(PageSize * (PageNumber - 1))
                .Take(PageSize)
                .ToListAsync();
            var totalItemsCount = baseQuery.Count();
            return new PagedResult<Entities.Review>(reviews, totalItemsCount, PageSize, PageNumber);
        }
    }
}
