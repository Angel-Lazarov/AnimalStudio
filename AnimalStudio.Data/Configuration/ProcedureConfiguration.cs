using AnimalStudio.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalStudio.Data.Configuration
{
	public class ProcedureConfiguration : IEntityTypeConfiguration<Procedure>
	{
		public void Configure(EntityTypeBuilder<Procedure> builder)
		{
			builder.HasData(this.SeedProcedures());
		}

		private IEnumerable<Procedure> SeedProcedures()
		{
			List<Procedure> procedures = new List<Procedure>()
			{
				new Procedure {Id = 1, Name = "HairCut", Description="Trimming or styling an animal's fur to maintain hygiene, comfort, and appearance.", Price = 20.56m },
				new Procedure { Id = 2, Name = "Vaccination", Description="Administering a vaccine to protect the animal from diseases and strengthen its immune system.",Price = 45.62m },
				new Procedure { Id = 3, Name = "Full Bath", Description="A thorough wash of the animal using suitable shampoos, followed by rinsing and drying to ensure cleanliness and a healthy coat.",Price = 10.23m },
				new Procedure { Id = 4, Name = "Medicine Exam", Description="A health check-up performed by a veterinarian to assess the animal’s overall condition and identify any potential medical issues.",Price = 12.50m },
				new Procedure {Id = 5, Name = "External deworming", Description="Removal of fleas, ticks, and other parasites", Price = 55.86m },
				new Procedure {Id = 6, Name = "Eye care", Description="Cleaning around the eyes to remove tear stains, discharge, and debris, ensuring comfort and preventing infections.", Price = 35.50m },
				new Procedure {Id = 7, Name = "De-shedding treatment", Description="A specialized grooming process to remove loose undercoat and reduce shedding, keeping the animal’s coat healthy and manageable.", Price = 57.90m },
				new Procedure {Id = 8, Name = "Nail trimming", Description="The process of carefully cutting or filing the nails of animals to prevent overgrowth, injury, and discomfort.", Price = 75.43m },
				new Procedure {Id = 9, Name = "Teeth cleaning", Description="A procedure where the animal's teeth are cleaned to remove plaque, tartar, and debris, helping to prevent dental disease and maintain oral health.", Price = 155.40m },
				new Procedure {Id = 10, Name = "Ear cleaning", Description="The process of gently cleaning the animal’s ears to remove dirt, wax, and debris, preventing infections and discomfort.", Price = 19.56m },
			};

			return procedures;
		}
	}

}
