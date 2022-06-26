using MangaLibrary.DataAccess.CQRS.Models;
using MangaLibrary.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Queries.Character
{
    public class GetCharactersQuery : QueryBase<PagedResult<MangaLibrary.DataAccess.Entities.Character>>
    {
        public string SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }

        public async override Task<PagedResult<MangaLibrary.DataAccess.Entities.Character>> Execute(MangaLibraryDbContext context)
        {
            var baseQuery = context
                .Characters
                .Where(n => SearchPhrase == null ||
                (n.Name.ToLower().Contains(SearchPhrase.ToLower())) ||
                (n.About.ToLower().Contains(SearchPhrase.ToLower())));


            if (!string.IsNullOrEmpty(SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<MangaLibrary.DataAccess.Entities.Character, object>>>
                {
                    { nameof(MangaLibrary.DataAccess.Entities.Character.Name), n => n.Name }
                   
                };
                var selectedColumn = columnsSelectors[SortBy];
                baseQuery = SortDirection == SortDirection.Ascending
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }
            var characters = await baseQuery
                .Skip(PageSize * (PageNumber - 1))
                .Take(PageSize)
                .ToListAsync();
            var totalItemsCount = baseQuery.Count();
            return new PagedResult<Entities.Character>(characters, totalItemsCount, PageSize, PageNumber);
        }
    }
}
