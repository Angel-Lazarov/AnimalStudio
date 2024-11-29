﻿// <auto-generated />
using System;
using AnimalStudio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnimalStudio.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AnimalStudio.Data.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Animal Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasComment("Age of the animal");

                    b.Property<int>("AnimalTypeId")
                        .HasColumnType("int")
                        .HasComment("Animal type Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("The name of the animal");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasComment("The user who is owner of the animal");

                    b.HasKey("Id");

                    b.HasIndex("AnimalTypeId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Animals", t =>
                        {
                            t.HasComment("An animal entity");
                        });
                });

            modelBuilder.Entity("AnimalStudio.Data.Models.AnimalType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("AnimalType Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnimalTypeName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Type of the animal");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)")
                        .HasComment("Description for the worker");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnimalTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnimalTypeName = "Cat",
                            Description = "A cat is a curious, independent creature with a knack for napping, playing, and purring. They may act aloof, but their playful antics and soft purrs melt hearts!",
                            ImageUrl = "/img/animal-types/cat.jpg"
                        },
                        new
                        {
                            Id = 2,
                            AnimalTypeName = "Dog",
                            Description = "A dog is a loyal, loving companion with a wagging tail and a heart full of joy. They’re always ready for a walk, a game, or a cuddle, making them the perfect best friend.",
                            ImageUrl = "/img/animal-types/dog.jpg"
                        },
                        new
                        {
                            Id = 3,
                            AnimalTypeName = "Sheep",
                            Description = "A sheep is a fluffy, four-legged ball of wool that loves to graze and baa. They may be quiet and laid-back, but they’ve got a whole flock of personality – and don’t forget their signature “baaa”!",
                            ImageUrl = "/img/animal-types/sheep.jpg"
                        },
                        new
                        {
                            Id = 4,
                            AnimalTypeName = "Duck",
                            Description = "A duck is a quacking, waddling expert in water and land. With their silly little feet and charming fluff, they’re always ready for a splash and a good time!",
                            ImageUrl = "/img/animal-types/duck.jpg"
                        },
                        new
                        {
                            Id = 5,
                            AnimalTypeName = "Parrot",
                            Description = "A parrot is a colorful, talkative bird with a personality as bright as its feathers. With a love for mimicry and a flair for the dramatic, they can turn any moment into a lively performance!",
                            ImageUrl = "/img/animal-types/parrot.jpg"
                        },
                        new
                        {
                            Id = 6,
                            AnimalTypeName = "Snake",
                            Description = "A snake is a sleek, slithering creature with a mysterious charm. With no legs but plenty of style, they glide through life with a smoothness that’s hard to match – and a hiss that keeps you on your toes!",
                            ImageUrl = "/img/animal-types/snake.jpg"
                        },
                        new
                        {
                            Id = 7,
                            AnimalTypeName = "Lizard",
                            Description = "A lizard is a small, scaly explorer with a cool, laid-back attitude. Whether they’re basking in the sun or darting around like tiny ninjas, they always bring a touch of reptilian charm.",
                            ImageUrl = "/img/animal-types/lizard.jpg"
                        },
                        new
                        {
                            Id = 8,
                            AnimalTypeName = "Guinea Pig",
                            Description = "A guinea pig is a small, friendly rodent that loves to squeak, snack on veggies, and cuddle. Despite its name, it’s not from the sea and isn’t a pig – it’s a fluffy bundle of joy!",
                            ImageUrl = "/img/animal-types/guineapig.png"
                        });
                });

            modelBuilder.Entity("AnimalStudio.Data.Models.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("AnimalStudio.Data.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int")
                        .HasComment("Identifier of the animal in the order");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Identifier of the owner of the order");

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int")
                        .HasComment("Identifier of the procedure in the order");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ProcedureId");

                    b.ToTable("Orders", t =>
                        {
                            t.HasComment("Order entity");
                        });
                });

            modelBuilder.Entity("AnimalStudio.Data.Models.Procedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Procedure Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)")
                        .HasComment("Description of the procedure");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Animal name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Procedure Price");

                    b.HasKey("Id");

                    b.ToTable("Procedures", t =>
                        {
                            t.HasComment("Procedure entity.");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Trimming or styling an animal's fur to maintain hygiene, comfort, and appearance.",
                            Name = "HairCut",
                            Price = 20.56m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Administering a vaccine to protect the animal from diseases and strengthen its immune system.",
                            Name = "Vaccination",
                            Price = 45.62m
                        },
                        new
                        {
                            Id = 3,
                            Description = "A thorough wash of the animal using suitable shampoos, followed by rinsing and drying to ensure cleanliness and a healthy coat.",
                            Name = "Full Bath",
                            Price = 10.23m
                        },
                        new
                        {
                            Id = 4,
                            Description = "A health check-up performed by a veterinarian to assess the animal’s overall condition and identify any potential medical issues.",
                            Name = "Medicine Exam",
                            Price = 12.50m
                        },
                        new
                        {
                            Id = 5,
                            Description = "Removal of fleas, ticks, and other parasites",
                            Name = "External deworming",
                            Price = 55.86m
                        },
                        new
                        {
                            Id = 6,
                            Description = "Cleaning around the eyes to remove tear stains, discharge, and debris, ensuring comfort and preventing infections.",
                            Name = "Eye care",
                            Price = 35.50m
                        },
                        new
                        {
                            Id = 7,
                            Description = "A specialized grooming process to remove loose undercoat and reduce shedding, keeping the animal’s coat healthy and manageable.",
                            Name = "De-shedding treatment",
                            Price = 57.90m
                        },
                        new
                        {
                            Id = 8,
                            Description = "The process of carefully cutting or filing the nails of animals to prevent overgrowth, injury, and discomfort.",
                            Name = "Nail trimming",
                            Price = 75.43m
                        },
                        new
                        {
                            Id = 9,
                            Description = "A procedure where the animal's teeth are cleaned to remove plaque, tartar, and debris, helping to prevent dental disease and maintain oral health.",
                            Name = "Teeth cleaning",
                            Price = 155.40m
                        },
                        new
                        {
                            Id = 10,
                            Description = "The process of gently cleaning the animal’s ears to remove dirt, wax, and debris, preventing infections and discomfort.",
                            Name = "Ear cleaning",
                            Price = 19.56m
                        });
                });

            modelBuilder.Entity("AnimalStudio.Data.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("worker Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)")
                        .HasComment("Description for the worker");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Worker name");

                    b.HasKey("Id");

                    b.ToTable("Workers", t =>
                        {
                            t.HasComment("Worker entity.");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "",
                            ImageUrl = "/img/workers/Donald-Trump.jpg",
                            Name = "Donald Trump"
                        },
                        new
                        {
                            Id = 2,
                            Description = "",
                            ImageUrl = "/img/workers/Vladimir-Putin.jpg",
                            Name = "Vladimir Putin"
                        },
                        new
                        {
                            Id = 3,
                            Description = "",
                            ImageUrl = "/img/workers/Xi_Jinping.jpg",
                            Name = "Xi Jinping"
                        },
                        new
                        {
                            Id = 4,
                            Description = "",
                            ImageUrl = "/img/workers/Narendra-Modi.jpg",
                            Name = "Narendra Modi"
                        },
                        new
                        {
                            Id = 5,
                            Description = "",
                            ImageUrl = "/img/workers/Boiko-Borisov.jpg",
                            Name = "Boiko Borisov"
                        },
                        new
                        {
                            Id = 6,
                            Description = "",
                            ImageUrl = "/img/workers/Boris-Johnson.jpg",
                            Name = "Boris Johnson"
                        },
                        new
                        {
                            Id = 7,
                            Description = "",
                            ImageUrl = "/img/workers/Eva-Mendes.jpg",
                            Name = "Eva Mendes"
                        },
                        new
                        {
                            Id = 8,
                            Description = "",
                            ImageUrl = "/img/workers/Josh-Holloway.jpg",
                            Name = "Josh Holloway"
                        },
                        new
                        {
                            Id = 9,
                            Description = "",
                            ImageUrl = "/img/workers/Natasha-Moneva.jpg",
                            Name = "Natasha Moneva"
                        },
                        new
                        {
                            Id = 10,
                            Description = "",
                            ImageUrl = "/img/workers/Deborah-De-Luca.jpg",
                            Name = "Deborah De Luca"
                        },
                        new
                        {
                            Id = 11,
                            Description = "",
                            ImageUrl = "",
                            Name = "Jennifer Lopez"
                        });
                });

            modelBuilder.Entity("AnimalStudio.Data.Models.WorkerProcedure", b =>
                {
                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("WorkerId", "ProcedureId");

                    b.HasIndex("ProcedureId");

                    b.ToTable("WorkersProcedures");

                    b.HasData(
                        new
                        {
                            WorkerId = 1,
                            ProcedureId = 1,
                            IsDeleted = false
                        },
                        new
                        {
                            WorkerId = 1,
                            ProcedureId = 3,
                            IsDeleted = false
                        },
                        new
                        {
                            WorkerId = 2,
                            ProcedureId = 4,
                            IsDeleted = false
                        },
                        new
                        {
                            WorkerId = 3,
                            ProcedureId = 2,
                            IsDeleted = false
                        },
                        new
                        {
                            WorkerId = 4,
                            ProcedureId = 2,
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AnimalStudio.Data.Models.Animal", b =>
                {
                    b.HasOne("AnimalStudio.Data.Models.AnimalType", "AnimalType")
                        .WithMany("Animals")
                        .HasForeignKey("AnimalTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnimalType");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("AnimalStudio.Data.Models.Manager", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithOne()
                        .HasForeignKey("AnimalStudio.Data.Models.Manager", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AnimalStudio.Data.Models.Order", b =>
                {
                    b.HasOne("AnimalStudio.Data.Models.Animal", "Animal")
                        .WithMany("Orders")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AnimalStudio.Data.Models.Procedure", "Procedure")
                        .WithMany("Orders")
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Owner");

                    b.Navigation("Procedure");
                });

            modelBuilder.Entity("AnimalStudio.Data.Models.WorkerProcedure", b =>
                {
                    b.HasOne("AnimalStudio.Data.Models.Procedure", "Procedure")
                        .WithMany("WorkersProcedures")
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AnimalStudio.Data.Models.Worker", "Worker")
                        .WithMany("WorkersProcedures")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Procedure");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AnimalStudio.Data.Models.Animal", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("AnimalStudio.Data.Models.AnimalType", b =>
                {
                    b.Navigation("Animals");
                });

            modelBuilder.Entity("AnimalStudio.Data.Models.Procedure", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("WorkersProcedures");
                });

            modelBuilder.Entity("AnimalStudio.Data.Models.Worker", b =>
                {
                    b.Navigation("WorkersProcedures");
                });
#pragma warning restore 612, 618
        }
    }
}
