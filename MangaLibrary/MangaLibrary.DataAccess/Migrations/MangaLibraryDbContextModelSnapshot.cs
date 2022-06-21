﻿// <auto-generated />
using System;
using MangaLibrary.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MangaLibrary.DataAccess.Migrations
{
    [DbContext(typeof(MangaLibraryDbContext))]
    partial class MangaLibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CreatorManga", b =>
                {
                    b.Property<Guid>("CreatorsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MangasId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CreatorsId", "MangasId");

                    b.HasIndex("MangasId");

                    b.ToTable("CreatorManga");
                });

            modelBuilder.Entity("GenreManga", b =>
                {
                    b.Property<Guid>("GenresId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MangasId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GenresId", "MangasId");

                    b.HasIndex("MangasId");

                    b.ToTable("GenreManga");
                });

            modelBuilder.Entity("MangaLibrary.DataAccess.Entities.Creator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("MangaLibrary.DataAccess.Entities.Demographic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Demographics");
                });

            modelBuilder.Entity("MangaLibrary.DataAccess.Entities.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MangaLibrary.DataAccess.Entities.Manga", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AnimeAdaptation")
                        .HasColumnType("bit");

                    b.Property<Guid>("DemographicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Heroes")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Story")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("DemographicId");

                    b.ToTable("Mangas");
                });

            modelBuilder.Entity("MangaLibrary.DataAccess.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("MangaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PublishDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("MangaId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MangaLibrary.DataAccess.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MangaLibrary.DataAccess.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MangaLibrary.DataAccess.Entities.Volume", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Arc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("MangaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MangaId");

                    b.ToTable("Volumes");
                });

            modelBuilder.Entity("CreatorManga", b =>
                {
                    b.HasOne("MangaLibrary.DataAccess.Entities.Creator", null)
                        .WithMany()
                        .HasForeignKey("CreatorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MangaLibrary.DataAccess.Entities.Manga", null)
                        .WithMany()
                        .HasForeignKey("MangasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreManga", b =>
                {
                    b.HasOne("MangaLibrary.DataAccess.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MangaLibrary.DataAccess.Entities.Manga", null)
                        .WithMany()
                        .HasForeignKey("MangasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MangaLibrary.DataAccess.Entities.Manga", b =>
                {
                    b.HasOne("MangaLibrary.DataAccess.Entities.Demographic", "Demographic")
                        .WithMany("Mangas")
                        .HasForeignKey("DemographicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Demographic");
                });

            modelBuilder.Entity("MangaLibrary.DataAccess.Entities.Review", b =>
                {
                    b.HasOne("MangaLibrary.DataAccess.Entities.User", "Author")
                        .WithMany("Reviews")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MangaLibrary.DataAccess.Entities.Manga", "Manga")
                        .WithMany("Reviews")
                        .HasForeignKey("MangaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Manga");
                });

            modelBuilder.Entity("MangaLibrary.DataAccess.Entities.User", b =>
                {
                    b.HasOne("MangaLibrary.DataAccess.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MangaLibrary.DataAccess.Entities.Volume", b =>
                {
                    b.HasOne("MangaLibrary.DataAccess.Entities.Manga", "Manga")
                        .WithMany("Volumes")
                        .HasForeignKey("MangaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manga");
                });

            modelBuilder.Entity("MangaLibrary.DataAccess.Entities.Demographic", b =>
                {
                    b.Navigation("Mangas");
                });

            modelBuilder.Entity("MangaLibrary.DataAccess.Entities.Manga", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Volumes");
                });

            modelBuilder.Entity("MangaLibrary.DataAccess.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MangaLibrary.DataAccess.Entities.User", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
