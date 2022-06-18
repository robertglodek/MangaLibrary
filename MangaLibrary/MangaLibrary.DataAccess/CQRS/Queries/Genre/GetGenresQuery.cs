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
    public class GetGenresQuery : QueryBase<Result<List<MangaLibrary.DataAccess.Entities.Genre>>>
    {
        public async override Task<Result<List<MangaLibrary.DataAccess.Entities.Genre>>> Execute(MangaLibraryDbContext context)
        {    
            var result=await context.Genres.ToListAsync();
            return Result<List<MangaLibrary.DataAccess.Entities.Genre>>.Success(result);
        }
    }
}
