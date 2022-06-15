using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Commands
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameter,TResult>(CommandBase<TParameter,TResult> command);
    }
}
