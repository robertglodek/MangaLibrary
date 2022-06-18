using MangaLibrary.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.Data
{
    public static class EntitiesConfiguration
    {
        
        public static ModelBuilder ConfigureEntities(this ModelBuilder builder)
        {
            builder.Entity<Creator>(n =>
            {
                n.HasKey(n => n.Id);
                n.Property(n => n.FirstName).IsRequired().HasMaxLength(40);
                n.Property(n => n.LastName).IsRequired().HasMaxLength(40);
                n.Property(n => n.Description).IsRequired().HasMaxLength(500);
                n.HasMany(n => n.Mangas).WithMany(n => n.Creators);
            });
            builder.Entity<Genre>(n => 
            {
                n.HasKey(n => n.Id);
                n.Property(n => n.Name).IsRequired().HasMaxLength(100);
                n.HasMany(n => n.Mangas).WithMany(n => n.Genres);
            });
            builder.Entity<Manga>(n =>
            {
                n.HasKey(n => n.Id);
                n.Property(n => n.Name).IsRequired().HasMaxLength(100);
                n.Property(n => n.Demographic).IsRequired().HasMaxLength(40);
                n.Property(n => n.Description).IsRequired().HasMaxLength(500);
                n.Property(n => n.Publisher).IsRequired().HasMaxLength(40);
                n.HasMany(n => n.Volumes).WithOne(n => n.Manga).HasForeignKey(n => n.MangaId);
                n.HasMany(n => n.Reviews).WithOne(n => n.Manga).HasForeignKey(n => n.MangaId);
            });
            builder.Entity<Review>(n =>
            {
                n.HasKey(n => n.Id);
                n.Property(n => n.Content).IsRequired().HasMaxLength(200);
                n.Property(n => n.PublishDate).HasDefaultValueSql("getutcdate()");
                n.HasOne(n => n.Author).WithMany(n => n.Reviews).HasForeignKey(n => n.AuthorId);    
            });
            builder.Entity<Role>(n =>
            {
                n.HasKey(n => n.Id);
                n.Property(n => n.Name).IsRequired().HasMaxLength(100);
                n.HasMany(n => n.Users).WithOne(n => n.Role).HasForeignKey(n => n.RoleId);
            });
            builder.Entity<User>(n =>
            {
                n.HasKey(n => n.Id);
                n.Property(n => n.FirstName).IsRequired().HasMaxLength(40);
                n.Property(n => n.LastName).IsRequired().HasMaxLength(40);
                n.Property(n => n.Email).IsRequired().HasMaxLength(100);
                n.Property(n => n.PasswordHash).IsRequired();
                n.Property(n => n.Nationality).IsRequired().HasMaxLength(40);
                n.Property(n => n.Nationality).IsRequired().HasMaxLength(40);
            });
            builder.Entity<Volume>(n =>
            {
                n.HasKey(n => n.Id);
                n.Property(n => n.Name).IsRequired().HasMaxLength(100);
                n.Property(n => n.Description).IsRequired().HasMaxLength(500);
                n.Property(n => n.Publisher).IsRequired().HasMaxLength(50);
            });

            return builder;
        }
    }
}
