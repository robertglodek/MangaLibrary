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
            builder.Entity<Demographic>(n =>
            {
                n.HasKey(n => n.Id);
                n.Property(n => n.Value).IsRequired().HasMaxLength(50);
                n.Property(n => n.Description).IsRequired().HasMaxLength(100);
                n.HasMany(n => n.Mangas).WithOne(n => n.Demographic).HasForeignKey(n => n.DemographicId);
               
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
                n.Property(n => n.Description).IsRequired().HasMaxLength(500);
                n.Property(n => n.Story).IsRequired().HasMaxLength(500);
                n.Property(n => n.Image).HasMaxLength(200);
                n.Property(n => n.Status).IsRequired().HasMaxLength(40);
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
            });
            builder.Entity<Volume>(n =>
            {
                n.HasKey(n => n.Id);
                n.Property(n => n.Name).IsRequired().HasMaxLength(100);
                n.Property(n => n.Description).IsRequired().HasMaxLength(500);
                n.Property(n => n.Arc).IsRequired().HasMaxLength(50);
            });
            builder.Entity<Character>(n =>
            {
                n.HasKey(n => n.Id);
                n.Property(n => n.Image).HasMaxLength(200);
                n.Property(n => n.Name).IsRequired().HasMaxLength(100);
                n.Property(n => n.About).IsRequired().HasMaxLength(500);
            });

            return builder;
        }
    }
}
