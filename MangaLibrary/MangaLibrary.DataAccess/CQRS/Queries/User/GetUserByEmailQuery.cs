using MangaLibrary.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Queries.User
{
    public class GetUserByEmailQuery:QueryBase<Result<MangaLibrary.DataAccess.Entities.User>>
    {
        public string Email { get; set; }

        public async override Task<Result<MangaLibrary.DataAccess.Entities.User>> Execute(MangaLibraryDbContext context)
        {
            var result = await context.Users.FirstOrDefaultAsync(n => n.Email == this.Email);
            if (result == null)
                return Result<MangaLibrary.DataAccess.Entities.User>.Fail($"User with Email {this.Email} doesn't exist");
            return Result<MangaLibrary.DataAccess.Entities.User>.Success(result);
        }
    }
}
