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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Animal Identifier");

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasComment("Age of the animal");

                    b.Property<int>("AnimalTypeId")
                        .HasColumnType("int")
                        .HasComment("Animal type Id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("AnimalTypes", t =>
                        {
                            t.HasComment("An AnimalType entity");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnimalTypeName = "Cat",
                            Description = "A cat is a curious, independent creature with a knack for napping, playing, and purring. They may act aloof, but their playful antics and soft purrs melt hearts!",
                            ImageUrl = "/img/animal-types/cat.jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            AnimalTypeName = "Dog",
                            Description = "A dog is a loyal, loving companion with a wagging tail and a heart full of joy. They’re always ready for a walk, a game, or a cuddle, making them the perfect best friend.",
                            ImageUrl = "/img/animal-types/dog.jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            AnimalTypeName = "Sheep",
                            Description = "A sheep is a fluffy, four-legged ball of wool that loves to graze and baa. They may be quiet and laid-back, but they’ve got a whole flock of personality – and don’t forget their signature “baaa”!",
                            ImageUrl = "/img/animal-types/sheep.jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 4,
                            AnimalTypeName = "Duck",
                            Description = "A duck is a quacking, waddling expert in water and land. With their silly little feet and charming fluff, they’re always ready for a splash and a good time!",
                            ImageUrl = "/img/animal-types/duck.jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 5,
                            AnimalTypeName = "Parrot",
                            Description = "A parrot is a colorful, talkative bird with a personality as bright as its feathers. With a love for mimicry and a flair for the dramatic, they can turn any moment into a lively performance!",
                            ImageUrl = "/img/animal-types/parrot.jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 6,
                            AnimalTypeName = "Snake",
                            Description = "A snake is a sleek, slithering creature with a mysterious charm. With no legs but plenty of style, they glide through life with a smoothness that’s hard to match – and a hiss that keeps you on your toes!",
                            ImageUrl = "/img/animal-types/snake.jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 7,
                            AnimalTypeName = "Lizard",
                            Description = "A lizard is a small, scaly explorer with a cool, laid-back attitude. Whether they’re basking in the sun or darting around like tiny ninjas, they always bring a touch of reptilian charm.",
                            ImageUrl = "/img/animal-types/lizard.jpg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 8,
                            AnimalTypeName = "Guinea Pig",
                            Description = "A guinea pig is a small, friendly rodent that loves to squeak, snack on veggies, and cuddle. Despite its name, it’s not from the sea and isn’t a pig – it’s a fluffy bundle of joy!",
                            ImageUrl = "/img/animal-types/guineapig.png",
                            IsDeleted = false
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

                    b.Property<Guid>("AnimalId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identifier of the animal in the order");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Identifier of the owner of the order");

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int")
                        .HasComment("Identifier of the procedure in the order");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date of order creation.");

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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Procedure name");

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
                            IsDeleted = false,
                            Name = "HairCut",
                            Price = 20.56m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Administering a vaccine to protect the animal from diseases and strengthen its immune system.",
                            IsDeleted = false,
                            Name = "Vaccination",
                            Price = 45.62m
                        },
                        new
                        {
                            Id = 3,
                            Description = "A thorough wash of the animal using suitable shampoos, followed by rinsing and drying to ensure cleanliness and a healthy coat.",
                            IsDeleted = false,
                            Name = "Full Bath",
                            Price = 10.23m
                        },
                        new
                        {
                            Id = 4,
                            Description = "A health check-up performed by a veterinarian to assess the animal’s overall condition and identify any potential medical issues.",
                            IsDeleted = false,
                            Name = "Medicine Exam",
                            Price = 12.50m
                        },
                        new
                        {
                            Id = 5,
                            Description = "Removal of fleas, ticks, and other parasites",
                            IsDeleted = false,
                            Name = "External deworming",
                            Price = 55.86m
                        },
                        new
                        {
                            Id = 6,
                            Description = "Cleaning around the eyes to remove tear stains, discharge, and debris, ensuring comfort and preventing infections.",
                            IsDeleted = false,
                            Name = "Eye care",
                            Price = 35.50m
                        },
                        new
                        {
                            Id = 7,
                            Description = "A specialized grooming process to remove loose undercoat and reduce shedding, keeping the animal’s coat healthy and manageable.",
                            IsDeleted = false,
                            Name = "De-shedding treatment",
                            Price = 57.90m
                        },
                        new
                        {
                            Id = 8,
                            Description = "The process of carefully cutting or filing the nails of animals to prevent overgrowth, injury, and discomfort.",
                            IsDeleted = false,
                            Name = "Nail trimming",
                            Price = 75.43m
                        },
                        new
                        {
                            Id = 9,
                            Description = "A procedure where the animal's teeth are cleaned to remove plaque, tartar, and debris, helping to prevent dental disease and maintain oral health.",
                            IsDeleted = false,
                            Name = "Teeth cleaning",
                            Price = 155.40m
                        },
                        new
                        {
                            Id = 10,
                            Description = "The process of gently cleaning the animal’s ears to remove dirt, wax, and debris, preventing infections and discomfort.",
                            IsDeleted = false,
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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

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
                            Description = "Dr. Alan Jakson is a skilled veterinarian with years of training and experience in animal wellness, dedicated to making every pet feel their best at our Animal Studio.",
                            ImageUrl = "/img/workers/Alan_Jakson.jpg",
                            IsDeleted = false,
                            Name = "Alan Jakson"
                        },
                        new
                        {
                            Id = 2,
                            Description = "With a strong background in animal care, Dr. Ana Lucia combines expertise and compassion to offer top-tier treatments at our Animal Studio.",
                            ImageUrl = "/img/workers/Ana_Lucia.jpg",
                            IsDeleted = false,
                            Name = "Ana Lucia"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Dr. Ben White, an experienced veterinarian, brings a wealth of knowledge and hands-on experience to our Animal Studio, ensuring the utmost comfort and healing for every pet.",
                            ImageUrl = "/img/workers/Ben_White.jpg",
                            IsDeleted = false,
                            Name = "Ben White"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Passionate about animal health, Dr. Debora Browning is an expert with extensive training who ensures that each visit to our Animal Studio is a soothing and therapeutic experience.",
                            ImageUrl = "/img/workers/Debora_Browning.jpg",
                            IsDeleted = false,
                            Name = "Debora Browning"
                        },
                        new
                        {
                            Id = 5,
                            Description = "As a dedicated professional, Dr. Dru Bening provides expert veterinary care with years of practice and a deep understanding of animal needs at our Animal Studio.",
                            ImageUrl = "/img/workers/Dru_Bening.jpg",
                            IsDeleted = false,
                            Name = "Dru Bening"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Dr. Haris Young combines years of veterinary training and real-world experience to deliver exceptional care, making pets feel cared for and pampered.",
                            ImageUrl = "/img/workers/Haris_Young.jpg",
                            IsDeleted = false,
                            Name = "Haris Young"
                        },
                        new
                        {
                            Id = 7,
                            Description = "With a rich background in animal health and well-being, Dr. Jake Nikson brings skill and dedication to every treatment at our Animal Studio.",
                            ImageUrl = "/img/workers/Jake_Nikson.jpg",
                            IsDeleted = false,
                            Name = "Jake Nikson"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Dr. Kate Smith is a committed veterinarian whose extensive experience ensures pets receive the highest standard of care and comfort during every visit.",
                            ImageUrl = "/img/workers/Kate_Smith.jpg",
                            IsDeleted = false,
                            Name = "Kate Smith"
                        },
                        new
                        {
                            Id = 9,
                            Description = "A veterinarian with years of hands-on experience, Dr. Lili Palmer offers tailored treatments that prioritize each pet’s comfort and health at our Animal Studio",
                            ImageUrl = "/img/workers/Lili_Palmer.jpg",
                            IsDeleted = false,
                            Name = "Lili Palmer"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Dr. Rahit Mazin is an experienced veterinary professional who pairs his/her vast training with a love for animals, creating a welcoming and healing environment at our Animal Studio.",
                            ImageUrl = "/img/workers/Rahit_Mazin.jpg",
                            IsDeleted = false,
                            Name = "Rahit Mazin"
                        },
                        new
                        {
                            Id = 11,
                            Description = "With significant training and a deep understanding of animal wellness, Dr. Stefan_Duglas delivers expert care and treatments that make every pet feel their best.",
                            ImageUrl = "",
                            IsDeleted = false,
                            Name = "Stefan Duglas"
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
