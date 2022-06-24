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
                    await _dbContext.Roles.AddRangeAsync(GetRoles());
                if (!await _dbContext.Genres.AnyAsync())
                    await _dbContext.Genres.AddRangeAsync(GetGenres());
                if (!await _dbContext.Demographics.AnyAsync())
                    await _dbContext.Demographics.AddRangeAsync(GetDemographics());

                await _dbContext.SaveChangesAsync();
           }
           return;
        }
        public static IEnumerable<Role> GetRoles()
        {
            var genres = new List<Role>()
            {
                new Role() { Name = UserRoleType.Admin },
                new Role() { Name = UserRoleType.User }
            };
            return genres;
        }

        public static IEnumerable<Genre> GetGenres()
        {
            var genres= new List<Genre>()
            {
                new Genre() { Name = "Action" }, new Genre() { Name = "Comedy" }, new Genre() { Name = "Drama" },
                new Genre() { Name = "Fantasy" }, new Genre() { Name = "Horror" }, new Genre() { Name = "Mystery" },
                new Genre() { Name = "Romance" }, new Genre() { Name = "Thriller" }, new Genre() { Name = "Western" },
            };
            return genres;
        }

        public static IEnumerable<Demographic> GetDemographics()
        {
            var genres = new List<Demographic>()
            {
                new Demographic() { Value = "Shonen", Description="Manga targeted at tween and teen boys" },
                new Demographic() { Value = "Shojo", Description="Manga targeted at tween and teen girls" },
                new Demographic() { Value = "Seinen", Description="Manga targeted at adult men (18+)" }, 
                new Demographic() { Value = "Josei", Description="Manga targeted at adult women (18+)" }, 
                new Demographic() { Value = "Kodomomuke", Description="Manga targeted at young children" }
            };
            return genres;
        }
    }
}
