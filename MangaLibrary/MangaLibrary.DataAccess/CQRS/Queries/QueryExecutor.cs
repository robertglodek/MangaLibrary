using MangaLibrary.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Queries
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly MangaLibraryDbContext _context;

        public QueryExecutor(MangaLibraryDbContext context)
        {
            _context = context;
        }
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this._context);
        }
    }
}
