using AnimalStudio.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalStudio.Data.Configuration
{
	public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
	{
		public void Configure(EntityTypeBuilder<Worker> builder)
		{
			builder
				.Property(w => w.IsDeleted)
				.IsRequired();

			builder.HasData(this.SeedWorkers());
		}

		private IEnumerable<Worker> SeedWorkers()
		{
			List<Worker> workers = new List<Worker>
			{
				new Worker { Id = 1, Name = "Donald Trump", ImageUrl = "/img/workers/Donald-Trump.jpg", Description = ""},
				new Worker { Id = 2, Name = "Vladimir Putin", ImageUrl = "/img/workers/Vladimir-Putin.jpg", Description = ""},
				new Worker { Id = 3, Name = "Xi Jinping", ImageUrl = "/img/workers/Xi_Jinping.jpg", Description = ""},
				new Worker { Id = 4, Name = "Narendra Modi", ImageUrl = "/img/workers/Narendra-Modi.jpg", Description = ""},
				new Worker { Id = 5, Name = "Boiko Borisov", ImageUrl = "/img/workers/Boiko-Borisov.jpg", Description = ""},
				new Worker { Id = 6, Name = "Boris Johnson", ImageUrl = "/img/workers/Boris-Johnson.jpg", Description = ""},
				new Worker { Id = 7, Name = "Eva Mendes", ImageUrl = "/img/workers/Eva-Mendes.jpg", Description = ""},
				new Worker { Id = 8, Name = "Josh Holloway", ImageUrl = "/img/workers/Josh-Holloway.jpg", Description = ""},
				new Worker { Id = 9, Name = "Natasha Moneva", ImageUrl = "/img/workers/Natasha-Moneva.jpg", Description = ""},
				new Worker { Id = 10, Name = "Deborah De Luca", ImageUrl = "/img/workers/Deborah-De-Luca.jpg", Description = ""},
				new Worker { Id = 11, Name = "Jennifer Lopez", ImageUrl = "", Description = ""}
			};

			return workers;
		}
	}

}
