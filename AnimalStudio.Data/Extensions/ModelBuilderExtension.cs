using AnimalStudio.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AnimalStudio.Data.Extensions
{
	public static class ModelBuilderExtension
	{
		public static void MappingEntity(this ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new AnimalConfiguration());
			modelBuilder.ApplyConfiguration(new OrderConfiguration());
			modelBuilder.ApplyConfiguration(new ManagerConfiguration());
			modelBuilder.ApplyConfiguration(new WorkerProcedureConfiguration());
		}
		public static void Seed(this ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new AnimalTypeConfiguration());
			modelBuilder.ApplyConfiguration(new ProcedureConfiguration());
			modelBuilder.ApplyConfiguration(new WorkerConfiguration());
		}
	}
}