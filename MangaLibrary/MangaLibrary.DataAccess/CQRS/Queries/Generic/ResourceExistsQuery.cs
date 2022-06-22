using MangaLibrary.DataAccess.Data;
using MangaLibrary.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Queries.Generic
{

    public class ResourceExistsQuery<T> : QueryBase<bool> where T : EntityBase
    {
        public Guid Id { get; init; }
        public string PropertiesToInclude { get; init; }
        public async override Task<bool> Execute(MangaLibraryDbContext context)
        {
            IQueryable<T> query = context.Set<T>();
            return await query.AnyAsync(n => n.Id == this.Id);
        }
    }
}
