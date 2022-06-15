using MangaLibrary.DataAccess.CQRS.Commands;
using MangaLibrary.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Commands
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly MangaLibraryDbContext _context;

        public CommandExecutor(MangaLibraryDbContext context)
        {
            _context = context;
        }

        public async Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command)
        {
            return await command.Execute(_context);
        }
    }
}
