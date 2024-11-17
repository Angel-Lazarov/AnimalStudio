﻿// <auto-generated />
using System;
using AnimalStudio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnimalStudio.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241117103259_ChangeWorkerProcedureToManyToMany")]
    partial class ChangeWorkerProcedureToManyToMany
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("AnimalStudio.Data.Models.AnimalProcedure", b =>
                {
                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.HasKey("AnimalId", "ProcedureId");

                    b.HasIndex("ProcedureId");

                    b.ToTable("AnimalsProcedures");
                });

            modelBuilder.Entity("AnimalStudio.Data.Models.AnimalType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("AnimalType Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnimalTypeInfo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Type of the animal");

                    b.HasKey("Id");

                    b.ToTable("AnimalTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnimalTypeInfo = "Cat"
                        },
                        new
                        {
                            Id = 2,
                            AnimalTypeInfo = "Dog"
                        },
                        new
                        {
                            Id = 3,
                            AnimalTypeInfo = "Sheep"
                        },
                        new
                        {
                            Id = 4,
                            AnimalTypeInfo = "Dog"
                        },
                        new
                        {
                            Id = 5,
                            AnimalTypeInfo = "Parrot"
                        },
                        new
                        {
                            Id = 6,
                            AnimalTypeInfo = "Snake"
                        },
                        new
                        {
                            Id = 7,
                            AnimalTypeInfo = "Lizard"
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
                            Description = "Some description here",
                            Name = "HairCut",
                            Price = 20.56m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Some description here",
                            Name = "Vaccination",
                            Price = 45.62m
                        },
                        new
                        {
                            Id = 3,
                            Description = "Some description here",
                            Name = "Full Bath",
                            Price = 10.23m
                        },
                        new
                        {
                            Id = 4,
                            Description = "Some description here",
                            Name = "Medicine Exam",
                            Price = 12.50m
                        });
                });

            modelBuilder.Entity("AnimalStudio.Data.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("worker Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Jane Smith"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Alex Johnson"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Emily Davis"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Michael Brown"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Sarah Wilson"
                        },
                        new
                        {
                            Id = 7,
                            Name = "David Lee"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Laura Garcia"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Chris Martin"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Anna Thompson"
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
                        .WithMany()
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

            modelBuilder.Entity("AnimalStudio.Data.Models.AnimalProcedure", b =>
                {
                    b.HasOne("AnimalStudio.Data.Models.Animal", "Animal")
                        .WithMany("AnimalProcedure")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AnimalStudio.Data.Models.Procedure", "Procedure")
                        .WithMany("AnimalProcedure")
                        .HasForeignKey("ProcedureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Animal");

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
                    b.Navigation("AnimalProcedure");
                });

            modelBuilder.Entity("AnimalStudio.Data.Models.Procedure", b =>
                {
                    b.Navigation("AnimalProcedure");

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
