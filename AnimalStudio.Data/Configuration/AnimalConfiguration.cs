using AnimalStudio.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalStudio.Data.Configuration
{
	public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
	{
		public void Configure(EntityTypeBuilder<Animal> builder)
		{
		}
	}
}
