using MangaLibrary.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Commands.Generic
{
    public class DeleteResourceCommand<T> : CommandBase<T, Guid> where T: Entities.EntityBase
    {
        public async override Task<Guid> Execute(MangaLibraryDbContext context)
        {
            var resourceId = this.Parameter.Id;
            context.Set<T>().Remove(this.Parameter);
            await context.SaveChangesAsync();
            return resourceId;
        }
    }
}
