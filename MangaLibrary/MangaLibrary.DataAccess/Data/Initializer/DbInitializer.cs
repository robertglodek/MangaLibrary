using MangaLibrary.DataAccess.Data.FixedData;
using MangaLibrary.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.Data.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly MangaLibraryDbContext _dbContext;

        public DbInitializer(MangaLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task InitializeAsync()
        {
           if (_dbContext.Database.CanConnect())
           {
                var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();

                if(!pendingMigrations.Any())
                    await _dbContext.Database.MigrateAsync();
                if(!await _dbContext.Roles.AnyAsync())
                {
                    var roles = new List<Role>();
                    roles.Add(new Role() { Name=UserRoleType.Admin });
                    roles.Add(new Role() { Name=UserRoleType.User });
                    await _dbContext.Roles.AddRangeAsync(roles);
                }
                if(!await _dbContext.Genres.AnyAsync())
                {
                    var genres = new List<Genre>();
                    genres.Add(new Genre() { Name = "Action" });
                    genres.Add(new Genre() { Name = "Comedy" });
                    genres.Add(new Genre() { Name = "Drama" });
                    genres.Add(new Genre() { Name = "Fantasy" });
                    genres.Add(new Genre() { Name = "Horror" });
                    genres.Add(new Genre() { Name = "Mystery" });
                    genres.Add(new Genre() { Name = "Romance" });
                    genres.Add(new Genre() { Name = "Thriller" });
                    genres.Add(new Genre() { Name = "Western" });
                    await _dbContext.Genres.AddRangeAsync(genres);
                }

                await _dbContext.SaveChangesAsync();
           }
           return;
        }
    }
}
