using MangaLibrary.DataAccess.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Commands.Genre
{
    public class AddGenreCommand : CommandBase<MangaLibrary.DataAccess.Entities.Genre, Result<Unit>>
    {
        public override async Task<Result<Unit>> Execute(MangaLibraryDbContext context)
        {
            await context.Genres.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return Result<Unit>.Success();
        }
    }
}
