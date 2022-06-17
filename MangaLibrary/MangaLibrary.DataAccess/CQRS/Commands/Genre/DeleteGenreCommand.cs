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
    public class DeleteGenreCommand : CommandBase<Guid, Result<Unit>>
    {
        public override async Task<Result<Unit>> Execute(MangaLibraryDbContext context)
        {
            var item=await context.Genres.FirstOrDefaultAsync(n => n.Id == this.Parameter);
            if (item == null)
                return Result<Unit>.Fail($"Genre with id: {this.Parameter} doesn't exist");
            context.Genres.Remove(item);
            await context.SaveChangesAsync();
            return Result<Unit>.Success();  
        }
    }
}
