using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.Data
{
    public class MangaLibraryDbContextFactory : IDesignTimeDbContextFactory<MangaLibraryDbContext>
    {
        private readonly string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=MangaLibrary;Integrated Security=True";
        public MangaLibraryDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MangaLibraryDbContext>();
            optionsBuilder.UseSqlServer(this.connectionString);
            return new MangaLibraryDbContext(optionsBuilder.Options);
        }
    }
}
