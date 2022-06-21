using MangaLibrary.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Commands
{
    public abstract class CommandBase<TParameter,TResult>
    {
        public TParameter Parameter { get; init; }

        public abstract Task<TResult> Execute(MangaLibraryDbContext context);
    }
}
