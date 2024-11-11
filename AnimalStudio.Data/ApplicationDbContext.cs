using AnimalStudio.Data.Extensions;
using AnimalStudio.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext()
		{
		}

		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public virtual DbSet<Animal> Animals { get; set; } = null!;

		public virtual DbSet<AnimalProcedure> AnimalProcedures { get; set; } = null!;

		public virtual DbSet<AnimalType> AnimalTypes { get; set; } = null!;

		public virtual DbSet<Procedure> Procedures { get; set; } = null!;

		public virtual DbSet<Worker> Workers { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//builder.Entity<AnimalProcedure>()
			//    .HasKey(ap => new { ap.AnimalId, ap.ProcedureId });

			//builder.Entity<AnimalProcedure>()
			//    .HasOne(ap => ap.Procedure)
			//    .WithMany(p => p.AnimalProcedure)
			//    .HasForeignKey(ap => ap.ProcedureId)
			//    .OnDelete(DeleteBehavior.Restrict);

			//builder.Entity<AnimalProcedure>()
			//    .HasOne(ap => ap.Animal)
			//    .WithMany(a => a.AnimalProcedure)
			//    .HasForeignKey(ap => ap.AnimalId)
			//    .OnDelete(DeleteBehavior.Restrict);

			builder.MappingEntity();
			builder.Seed();

			base.OnModelCreating(builder);

			//builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		}
	}
}
