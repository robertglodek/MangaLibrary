using MangaLibrary.DataAccess.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Commands.User
{
    public class AddUserCommand : CommandBase<MangaLibrary.DataAccess.Entities.User, Result<Unit>>
    {
        public async override Task<Result<Unit>> Execute(MangaLibraryDbContext context)
        {
            context.Users.Add(this.Parameter);
            await context.SaveChangesAsync();
            return Result<Unit>.Success();
        }
    }
}
