using MangaLibrary.DataAccess.CQRS.Models;
using MangaLibrary.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Queries.User
{
    public class GetUsersQuery : QueryBase<PagedResult<MangaLibrary.DataAccess.Entities.User>>
    {
        public string SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }

        public async override Task<PagedResult<MangaLibrary.DataAccess.Entities.User>> Execute(MangaLibraryDbContext context)
        {
            var baseQuery = context
                .Users
                .Include(n => n.Role)
                .Where(n => SearchPhrase == null || 
                (n.FirstName.ToLower().Contains(SearchPhrase.ToLower())) || 
                (n.LastName.ToLower().Contains(SearchPhrase.ToLower())) || 
                (n.Email.ToLower().Contains(SearchPhrase.ToLower())));


            if (!string.IsNullOrEmpty(SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<MangaLibrary.DataAccess.Entities.User, object>>>
                {
                    { nameof(MangaLibrary.DataAccess.Entities.User.FirstName), n => n.FirstName },
                    { nameof(MangaLibrary.DataAccess.Entities.User.LastName), n => n.LastName },
                    { nameof(MangaLibrary.DataAccess.Entities.User.DateOfBirth), n => n.DateOfBirth},
                    { nameof(MangaLibrary.DataAccess.Entities.User.Nationality), n => n.Nationality},
                    { nameof(MangaLibrary.DataAccess.Entities.User.Email), n => n.Email}
                };

                var selectedColumn = columnsSelectors[SortBy];

                baseQuery = SortDirection == SortDirection.Ascending
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }
            var users = await baseQuery
                .Skip(PageSize * (PageNumber - 1))
                .Take(PageSize)
                .ToListAsync();
            var totalItemsCount = baseQuery.Count();
            return new PagedResult<Entities.User>(users, totalItemsCount, PageSize, PageNumber);
        }
    }
}
