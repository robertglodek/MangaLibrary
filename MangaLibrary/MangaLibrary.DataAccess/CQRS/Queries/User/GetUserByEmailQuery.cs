using MangaLibrary.DataAccess.CQRS.Models;
using MangaLibrary.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Queries.User
{
    public class GetUserByEmailQuery : QueryBase<MangaLibrary.DataAccess.Entities.User>
    {
        public string Email { get; set; }

        public async override Task<MangaLibrary.DataAccess.Entities.User> Execute(MangaLibraryDbContext context)
        {
            var item = await context.Users.FirstOrDefaultAsync(n => n.Email == this.Email);
            return item;
        }
    }
}
