using MangaLibrary.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Queries.Genre
{
    public class GetGenresQuery : QueryBase<List<MangaLibrary.DataAccess.Entities.Genre>>
    {
        public async override Task<List<Entities.Genre>> Execute(MangaLibraryDbContext context)
        {
            return await context.Genres.ToListAsync();
        }
    }
}
