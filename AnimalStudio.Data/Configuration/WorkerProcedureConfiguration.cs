using AnimalStudio.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalStudio.Data.Configuration
{
	public class WorkerProcedureConfiguration : IEntityTypeConfiguration<WorkerProcedure>
	{
		public void Configure(EntityTypeBuilder<WorkerProcedure> builder)
		{
			builder.HasKey(wp => new { wp.WorkerId, wp.ProcedureId });

			builder
				.Property(wp => wp.IsDeleted)
				.HasDefaultValue(false);

			builder
				.HasOne(wp => wp.Worker)
				.WithMany(w => w.WorkersProcedures)
				.HasForeignKey(wp => wp.WorkerId)
				.OnDelete(DeleteBehavior.Restrict);
			//.OnDelete(DeleteBehavior.NoAction);

			builder
				.HasOne(wp => wp.Procedure)
				.WithMany(p => p.WorkersProcedures)
				.HasForeignKey(wp => wp.ProcedureId)
				.OnDelete(DeleteBehavior.Restrict);
			//.OnDelete(DeleteBehavior.NoAction);

			builder.HasData(this.SeedWorkerProcedure());
		}

		private IEnumerable<WorkerProcedure> SeedWorkerProcedure()
		{
			List<WorkerProcedure> workerProcedures = new List<WorkerProcedure>()
			{
				new WorkerProcedure {WorkerId = 1, ProcedureId = 1, IsDeleted = false},
				new WorkerProcedure {WorkerId = 1, ProcedureId = 3, IsDeleted = false},
				new WorkerProcedure {WorkerId = 2, ProcedureId = 4, IsDeleted = false},
				new WorkerProcedure {WorkerId = 3, ProcedureId = 2, IsDeleted = false},
				new WorkerProcedure {WorkerId = 4, ProcedureId = 2, IsDeleted = false},
			};

			return workerProcedures;
		}
	}
}