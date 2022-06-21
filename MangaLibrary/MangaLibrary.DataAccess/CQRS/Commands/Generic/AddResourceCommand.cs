using MangaLibrary.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Commands.Generic
{
    public class AddResourceCommand<T> : CommandBase<T, T> where T : Entities.EntityBase
    {
        public async override Task<T> Execute(MangaLibraryDbContext context)
        {
            await context.Set<T>().AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
