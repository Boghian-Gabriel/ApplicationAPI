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
    [Migration("20221003154231_seed")]
    partial class seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.Property<Guid>("ActorsActorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MoviesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ActorsActorId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("ActorMovie");
                });

            modelBuilder.Entity("API.Model.Actor", b =>
                {
                    b.Property<Guid>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("API.Model.ActorAdress", b =>
                {
                    b.Property<Guid>("ActorAdressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adress2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("ActorAdressId");

                    b.ToTable("ActorAdress");
                });

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
                            Id = new Guid("ce67744b-4645-4616-be7c-ecdaaba14e8f"),
                            IdRefGenre = new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"),
                            RealeseDate = new DateTime(2012, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "John Wick 1"
                        },
                        new
                        {
                            Id = new Guid("5000da5a-1502-498e-b0e9-fdefbb68e78b"),
                            IdRefGenre = new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"),
                            RealeseDate = new DateTime(207, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "John Wick 2"
                        },
                        new
                        {
                            Id = new Guid("7814e35d-f242-4bc2-b340-db0a24078085"),
                            IdRefGenre = new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"),
                            RealeseDate = new DateTime(2008, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Avatar 1"
                        },
                        new
                        {
                            Id = new Guid("8b1c571b-ee1b-4513-a12a-65055517c6ce"),
                            IdRefGenre = new Guid("917c3492-f531-44de-a321-b9b17a7a90e4"),
                            RealeseDate = new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Avatar 2"
                        },
                        new
                        {
                            Id = new Guid("fba72dac-37b7-424d-be82-82bf1d2de7e5"),
                            IdRefGenre = new Guid("7252f1ba-4885-411e-9ae2-5b8b801be464"),
                            RealeseDate = new DateTime(2008, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Mr. Bean"
                        },
                        new
                        {
                            Id = new Guid("8bd701ff-0814-48bd-90d5-a78754eb5def"),
                            IdRefGenre = new Guid("1ce57ea2-8b3b-4074-9264-60a92872dd98"),
                            RealeseDate = new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Film Example3"
                        },
                        new
                        {
                            Id = new Guid("bde22f26-dd6f-46da-b0e0-bb9d2a2b91c9"),
                            IdRefGenre = new Guid("d3dbc108-f55a-4acb-28d7-08daa4ff6e55"),
                            RealeseDate = new DateTime(2008, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Western P2"
                        },
                        new
                        {
                            Id = new Guid("c14c45b6-fbd7-4737-bab8-1c7a503a5b7d"),
                            IdRefGenre = new Guid("133d337e-5a77-4107-89de-210783900c1d"),
                            RealeseDate = new DateTime(2000, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Mascatul"
                        },
                        new
                        {
                            Id = new Guid("d47fc23e-ad3c-4c54-aaa5-a6bbce527c2a"),
                            IdRefGenre = new Guid("7c6abc48-36c0-4cec-aed7-0a5161c22b0f"),
                            RealeseDate = new DateTime(1934, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Film Example6"
                        },
                        new
                        {
                            Id = new Guid("5e1a8f55-7445-46fb-b737-2d1828717863"),
                            IdRefGenre = new Guid("133d337e-5a77-4107-89de-210783900c1d"),
                            RealeseDate = new DateTime(1995, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Mascatul P2"
                        },
                        new
                        {
                            Id = new Guid("a1c3a9cd-d926-499a-b098-38d6b3be1120"),
                            IdRefGenre = new Guid("2b44ee54-2d50-437c-996d-40525e268186"),
                            RealeseDate = new DateTime(2007, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The horses"
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

            modelBuilder.Entity("ActorMovie", b =>
                {
                    b.HasOne("API.Model.Actor", null)
                        .WithMany()
                        .HasForeignKey("ActorsActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Model.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Model.ActorAdress", b =>
                {
                    b.HasOne("API.Model.Actor", "Actor")
                        .WithOne("Adress")
                        .HasForeignKey("API.Model.ActorAdress", "ActorAdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");
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

            modelBuilder.Entity("API.Model.Actor", b =>
                {
                    b.Navigation("Adress")
                        .IsRequired();
                });

            modelBuilder.Entity("API.Model.Genre", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
