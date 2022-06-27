using MangaLibrary.DataAccess.CQRS.Models;
using MangaLibrary.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Queries.Manga
{

    public class GetMangasQuery : QueryBase<PagedResult<MangaLibrary.DataAccess.Entities.Manga>>
    {
        public string SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
        public string Demographic { get; set; }
        public string Genre { get; set; }

        public async override Task<PagedResult<MangaLibrary.DataAccess.Entities.Manga>> Execute(MangaLibraryDbContext context)
        {
            var baseQuery = context
                .Mangas
                .Include(n => n.Creators)
                .Include(n => n.Genres)
                .Include(n => n.Reviews)
                .Include(n => n.Demographic)
                .Where(n => (SearchPhrase == null || (n.Name.ToLower().Contains(SearchPhrase.ToLower())) || (n.Story.ToLower().Contains(SearchPhrase.ToLower()))) 
                && (Demographic==null || n.Demographic.Value==Demographic ) 
                && (Genre==null || n.Genres.FirstOrDefault(n=>n.Name==Genre)!=null));


            if (!string.IsNullOrEmpty(SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<MangaLibrary.DataAccess.Entities.Manga, object>>>
                {
                    { nameof(MangaLibrary.DataAccess.Entities.Manga.Status), n => n.Status },
                    { nameof(MangaLibrary.DataAccess.Entities.Manga.Name), n => n.Name },
                    { nameof(MangaLibrary.DataAccess.Entities.Manga.Demographic), n => n.Demographic},
                };
                var selectedColumn = columnsSelectors[SortBy];
                baseQuery = SortDirection == SortDirection.Ascending
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }
            var mangas = await baseQuery
                .Skip(PageSize * (PageNumber - 1))
                .Take(PageSize)
                .ToListAsync();
          
            var totalItemsCount = baseQuery.Count();
            return new PagedResult<Entities.Manga>(mangas, totalItemsCount, PageSize, PageNumber);
        }
    }
}
