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
    public class UpdateCreatorCommand : CommandBase<MangaLibrary.DataAccess.Entities.Creator, Result<Unit>>
    {
        public async override Task<Result<Unit>> Execute(MangaLibraryDbContext context)
        {
            var genre = await context.Creators.FirstOrDefaultAsync(n => n.Id == this.Parameter.Id);
            if (genre == null)
                return Result<Unit>.Fail($"Genre with id: {this.Parameter.Id} doesn't exist");
            context.Creators.Update(this.Parameter);
            await context.SaveChangesAsync();
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
