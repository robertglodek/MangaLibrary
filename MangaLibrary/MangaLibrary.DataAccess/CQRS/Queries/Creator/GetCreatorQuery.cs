using MangaLibrary.DataAccess.CQRS.Models;
using MangaLibrary.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Queries.Creator
{
    public class GetCreatorQuery : QueryBase<Result<MangaLibrary.DataAccess.Entities.Creator>>
    {
        public Guid Id { get; set; }

        public async override Task<Result<Entities.Creator>> Execute(MangaLibraryDbContext context)
        {
            var creator = await context.Creators.FirstOrDefaultAsync(x => x.Id == Id);
            if (creator == null)
                return Result<MangaLibrary.DataAccess.Entities.Creator>.Fail($"Genre with id: {Id} doesn't exist");
            return Result<MangaLibrary.DataAccess.Entities.Creator>.Success(creator);
        }

    }
}
