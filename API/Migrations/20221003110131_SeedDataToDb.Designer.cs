// <auto-generated />
using System;
using API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ContextDB))]
    [Migration("20221003110131_SeedDataToDb")]
    partial class SeedDataToDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API.Model.Genre", b =>
                {
                    b.Property<Guid>("IdGenre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGenre");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            IdGenre = new Guid("d3dbc108-f55a-4acb-28d7-08daa4ff6e55"),
                            GenreName = "Western"
                        },
                        new
                        {
                            IdGenre = new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"),
                            GenreName = "Action"
                        },
                        new
                        {
                            IdGenre = new Guid("133d337e-5a77-4107-89de-210783900c1d"),
                            GenreName = "Horror"
                        },
                        new
                        {
                            IdGenre = new Guid("2b44ee54-2d50-437c-996d-40525e268186"),
                            GenreName = "Drama"
                        },
                        new
                        {
                            IdGenre = new Guid("7252f1ba-4885-411e-9ae2-5b8b801be464"),
                            GenreName = "Commedy"
                        },
                        new
                        {
                            IdGenre = new Guid("1ce57ea2-8b3b-4074-9264-60a92872dd98"),
                            GenreName = "Crime"
                        },
                        new
                        {
                            IdGenre = new Guid("d5581b46-80e8-4ba0-b357-824130f9a779"),
                            GenreName = "Historical"
                        },
                        new
                        {
                            IdGenre = new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"),
                            GenreName = "Science Fiction"
                        },
                        new
                        {
                            IdGenre = new Guid("8650a45d-ee1d-46a4-8b7f-d8a8bae09f83"),
                            GenreName = "Science Fiction2 "
                        });
                });

            modelBuilder.Entity("API.Model.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdRefGenre")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RealeseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdRefGenre");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("db0e705c-1f7b-4a61-93d3-087799c35d3f"),
                            IdRefGenre = new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"),
                            RealeseDate = new DateTime(2012, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "John Wick 1"
                        });
                });

            modelBuilder.Entity("API.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Model.Movie", b =>
                {
                    b.HasOne("API.Model.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("IdRefGenre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("API.Model.Genre", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
