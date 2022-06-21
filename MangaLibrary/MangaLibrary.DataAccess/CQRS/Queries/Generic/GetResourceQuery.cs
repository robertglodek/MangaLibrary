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
    public class GetResourceQuery<T> : QueryBase<T> where T : EntityBase
    {
        public Guid Id { get; init; }
        public string PropertiesToInclude { get; init; }
        public async override Task<T> Execute(MangaLibraryDbContext context)
        {
            IQueryable<T> query = context.Set<T>();
            if (PropertiesToInclude != null)
            {
                foreach (var includeProp in PropertiesToInclude.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.FirstOrDefaultAsync(n => n.Id == this.Id);
        }
    }
}
