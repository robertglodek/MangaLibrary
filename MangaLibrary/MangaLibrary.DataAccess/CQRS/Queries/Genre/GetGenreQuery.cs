using MangaLibrary.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MangaLibrary.DataAccess.CQRS.Queries.Genre
{
    public class GetGenreQuery : QueryBase<MangaLibrary.DataAccess.Entities.Genre>
    {
        public Guid Id { get; set; }
        public async override Task<Entities.Genre> Execute(MangaLibraryDbContext context)
        {
            var genre= await context.Genres.FirstOrDefaultAsync(x=>x.Id==Id);
            return genre;
        }
    }
}
