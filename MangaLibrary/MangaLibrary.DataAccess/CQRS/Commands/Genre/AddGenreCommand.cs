using MangaLibrary.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Commands.Genre
{
    public class AddGenreCommand : CommandBase<MangaLibrary.DataAccess.Entities.Genre, MangaLibrary.DataAccess.Entities.Genre>
    {
        public override async Task<Entities.Genre> Execute(MangaLibraryDbContext context)
        {
            await context.Genres.AddAsync(this.Parameter);
            await context.SaveChangesAsync();

            return this.Parameter;
        }
    }
}
