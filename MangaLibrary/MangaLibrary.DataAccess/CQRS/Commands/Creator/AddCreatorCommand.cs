using MangaLibrary.DataAccess.CQRS.Models;
using MangaLibrary.DataAccess.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Commands.Creator
{
    public class AddCreatorCommand : CommandBase<MangaLibrary.DataAccess.Entities.Creator, Result<Unit>>
    {
        public async override Task<Result<Unit>> Execute(MangaLibraryDbContext context)
        {
            await context.Creators.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
