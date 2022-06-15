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
    public class DeleteGenreCommand : CommandBase<Guid, Unit>
    {

        public override async Task<Unit> Execute(MangaLibraryDbContext context)
        {
            var item=await context.Genres.FirstOrDefaultAsync(n => n.Id == this.Parameter);
            context.Genres.Remove(item);
            await context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
