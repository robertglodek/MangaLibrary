﻿using MangaLibrary.DataAccess.CQRS.Models;
using MangaLibrary.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.CQRS.Queries.User
{
    public class GetUserByIdQuery : QueryBase<Result<MangaLibrary.DataAccess.Entities.User>>
    {
        public Guid Id { get; set; }

        public async override Task<Result<MangaLibrary.DataAccess.Entities.User>> Execute(MangaLibraryDbContext context)
        {
            var result = await context.Users.FirstOrDefaultAsync(n => n.Id == this.Id);
            if (result == null)
                return Result<MangaLibrary.DataAccess.Entities.User>.Fail($"User with Email {this.Id} doesn't exist");
            return Result<MangaLibrary.DataAccess.Entities.User>.Success(result);
        }
    }
}
