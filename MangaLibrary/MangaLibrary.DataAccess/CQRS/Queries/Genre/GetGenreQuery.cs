using MangaLibrary.DataAccess.CQRS.Models;
using MangaLibrary.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MangaLibrary.DataAccess.CQRS.Queries.Genre
{
    public class GetGenreQuery : QueryBase<Result<MangaLibrary.DataAccess.Entities.Genre>>
    {
        public Guid Id { get; set; }
        public async override Task<Result<MangaLibrary.DataAccess.Entities.Genre>> Execute(MangaLibraryDbContext context)
        {
            var genre= await context.Genres.FirstOrDefaultAsync(x=>x.Id==Id);
            if(genre==null)
                return Result<MangaLibrary.DataAccess.Entities.Genre>.Fail($"Genre with id: {Id} doesn't exist");
            return Result<MangaLibrary.DataAccess.Entities.Genre>.Success(genre);
        }
    }
}
