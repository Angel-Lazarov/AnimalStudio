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
		public virtual DbSet<AnimalType> AnimalTypes { get; set; } = null!;
		public virtual DbSet<Procedure> Procedures { get; set; } = null!;
		public virtual DbSet<Worker> Workers { get; set; } = null!;
		public virtual DbSet<WorkerProcedure> WorkersProcedures { get; set; } = null!;
		public virtual DbSet<Order> Orders { get; set; } = null!;
		public virtual DbSet<Manager> Managers { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.MappingEntity();
			builder.Seed();

			base.OnModelCreating(builder);

			//builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
