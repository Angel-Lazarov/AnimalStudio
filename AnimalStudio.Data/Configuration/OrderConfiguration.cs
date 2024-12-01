using AnimalStudio.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalStudio.Data.Configuration
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.HasKey(o => o.Id);

			builder
				.Property(o => o.IsDeleted)
				.IsRequired();

			builder.HasOne(o => o.Owner)
				.WithMany()
				.HasForeignKey(o => o.OwnerId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(o => o.Animal)
				.WithMany(a => a.Orders)
				.HasForeignKey(o => o.AnimalId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(o => o.Procedure)
				.WithMany(p => p.Orders)
				.HasForeignKey(o => o.ProcedureId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
