using MangaLibrary.DataAccess.CQRS.Models;
using MangaLibrary.DataAccess.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Commands.Creator
{
    public class DeleteCreatorCommand : CommandBase<Guid, Result<Unit>>
    {
        public async override Task<Result<Unit>> Execute(MangaLibraryDbContext context)
        {
            var item = await context.Creators.FirstOrDefaultAsync(n => n.Id == this.Parameter);
            if (item == null)
                return Result<Unit>.Fail($"Creator with id: {this.Parameter} doesn't exist");
            context.Creators.Remove(item);
            await context.SaveChangesAsync();
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
