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
				.IsRequired()
				.HasDefaultValue(false);

			builder
				.HasOne(wp => wp.Worker)
				.WithMany(w => w.WorkersProcedures)
				.HasForeignKey(wp => wp.WorkerId)
				.OnDelete(DeleteBehavior.Restrict);

			builder
				.HasOne(wp => wp.Procedure)
				.WithMany(p => p.WorkersProcedures)
				.HasForeignKey(wp => wp.ProcedureId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasData(this.SeedWorkerProcedure());
		}

		private IEnumerable<WorkerProcedure> SeedWorkerProcedure()
		{
			List<WorkerProcedure> workerProcedures = new List<WorkerProcedure>()
			{
				new WorkerProcedure {WorkerId = 1, ProcedureId = 1, IsDeleted = false},
				new WorkerProcedure {WorkerId = 1, ProcedureId = 2, IsDeleted = false},
				new WorkerProcedure {WorkerId = 2, ProcedureId = 2, IsDeleted = false},
				new WorkerProcedure {WorkerId = 3, ProcedureId = 3, IsDeleted = false},
				new WorkerProcedure {WorkerId = 3, ProcedureId = 1, IsDeleted = false},
				new WorkerProcedure {WorkerId = 4, ProcedureId = 4, IsDeleted = false},
				new WorkerProcedure {WorkerId = 5, ProcedureId = 5, IsDeleted = false},
				new WorkerProcedure {WorkerId = 6, ProcedureId = 6, IsDeleted = false},
				new WorkerProcedure {WorkerId = 7, ProcedureId = 7, IsDeleted = false},
				new WorkerProcedure {WorkerId = 8, ProcedureId = 8, IsDeleted = false},
				new WorkerProcedure {WorkerId = 9, ProcedureId = 9, IsDeleted = false},
				new WorkerProcedure {WorkerId = 10, ProcedureId = 10, IsDeleted = false},
				new WorkerProcedure {WorkerId = 11, ProcedureId = 10, IsDeleted = false}
			};

			return workerProcedures;
		}
	}
}