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
    public class GetResourcesQuery<T> : QueryBase<List<T>> where T : EntityBase
    {
        public IEnumerable<Guid> Ids { get; set; }
        public string PropertiesToInclude { get; set; }
        public async override Task<List<T>> Execute(MangaLibraryDbContext context)
        {

            IQueryable<T> query = context.Set<T>();
            if (PropertiesToInclude != null)
            {
                foreach (var includeProp in PropertiesToInclude.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.ToListAsync();
        }
    }
}
