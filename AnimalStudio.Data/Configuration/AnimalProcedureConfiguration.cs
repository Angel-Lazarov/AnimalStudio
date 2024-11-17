using AnimalStudio.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalStudio.Data.Configuration
{
	public class AnimalProcedureConfiguration : IEntityTypeConfiguration<
		AnimalProcedure>
	{
		public void Configure(EntityTypeBuilder<AnimalProcedure> builder)
		{
			builder.HasKey(ap => new { ap.AnimalId, ap.ProcedureId });

			builder
				.HasOne(ap => ap.Procedure)
				.WithMany(p => p.AnimalProcedure)
				.HasForeignKey(ap => ap.ProcedureId)
				.OnDelete(DeleteBehavior.Restrict);

			builder
				.HasOne(ap => ap.Animal)
				.WithMany(a => a.AnimalProcedure)
				.HasForeignKey(ap => ap.AnimalId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}