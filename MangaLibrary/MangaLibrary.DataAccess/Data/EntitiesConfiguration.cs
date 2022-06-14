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
                n.Property(n => n.FirstName).HasMaxLength(40);
                n.Property(n => n.LastName).HasMaxLength(40);
                n.Property(n => n.ImagePath).HasMaxLength(200);
                n.Property(n => n.Nationality).HasMaxLength(40);
                n.Property(n => n.Description).HasMaxLength(500);
                n.HasMany(n => n.Mangas).WithMany(n => n.Creators);
            });
            builder.Entity<Genre>(n => 
            {
                n.HasKey(n => n.Id);
                n.Property(n => n.Name).HasMaxLength(100);
                n.HasMany(n => n.Mangas).WithMany(n => n.Genres);
            });
            builder.Entity<Manga>(n =>
            {
                n.HasKey(n => n.Id);
                n.Property(n => n.Name).HasMaxLength(100);
                n.Property(n => n.Demographic).HasMaxLength(40);
                n.Property(n => n.Description).HasMaxLength(500);
                n.Property(n => n.Publisher).HasMaxLength(40);
                n.Property(n => n.ImagePath).HasMaxLength(200);
                n.HasMany(n => n.Volumes).WithOne(n => n.Manga).HasForeignKey(n => n.MangaId);
                n.HasMany(n => n.Reviews).WithOne(n => n.Manga).HasForeignKey(n => n.MangaId);
            });
            builder.Entity<Review>(n =>
            {
                n.HasKey(n => n.Id);
                n.Property(n => n.Content).HasMaxLength(200);
                n.Property(n => n.PublishDate).HasDefaultValueSql("getutcdate()");
                n.HasOne(n => n.Author).WithMany(n => n.Reviews).HasForeignKey(n => n.AuthorId);    
            });
            builder.Entity<Role>(n =>
            {
                n.HasKey(n => n.Id);
                n.Property(n => n.Name).HasMaxLength(100);
                n.HasMany(n => n.Users).WithOne(n => n.Role).HasForeignKey(n => n.RoleId);
            });
            builder.Entity<User>(n =>
            {
                n.HasKey(n => n.Id);
                n.Property(n => n.FirstName).HasMaxLength(40);
                n.Property(n => n.LastName).HasMaxLength(40);
                n.Property(n => n.Email).HasMaxLength(100);
                n.Property(n => n.Nationality).HasMaxLength(40);
            });
            builder.Entity<Volume>(n =>
            {
                n.HasKey(n => n.Id);
                n.Property(n => n.Name).HasMaxLength(100);
                n.Property(n => n.ImagePath).HasMaxLength(200);
                n.Property(n => n.Description).HasMaxLength(500);
                n.Property(n => n.Publisher).HasMaxLength(50);
            });

            return builder;
        }
    }
}
