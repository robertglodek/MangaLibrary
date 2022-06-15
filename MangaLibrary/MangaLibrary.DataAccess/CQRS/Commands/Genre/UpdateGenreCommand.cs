using MangaLibrary.DataAccess.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Commands.Genre
{
    public class UpdateGenreCommand : CommandBase<MangaLibrary.DataAccess.Entities.Genre, Unit>
    {
        public async override Task<Unit> Execute(MangaLibraryDbContext context)
        {
            context.Genres.Update(this.Parameter);
            await context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
