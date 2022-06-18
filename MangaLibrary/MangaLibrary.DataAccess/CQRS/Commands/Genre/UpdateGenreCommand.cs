using MangaLibrary.DataAccess.CQRS.Models;
using MangaLibrary.DataAccess.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Commands.Genre
{
    public class UpdateGenreCommand : CommandBase<MangaLibrary.DataAccess.Entities.Genre, Result<Unit>>
    {
        public async override Task<Result<Unit>> Execute(MangaLibraryDbContext context)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(n=>n.Id==this.Parameter.Id);
            if (genre == null)
                return Result<Unit>.Fail($"Genre with id: {this.Parameter.Id} doesn't exist");
            context.Genres.Update(this.Parameter);
            await context.SaveChangesAsync();
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
