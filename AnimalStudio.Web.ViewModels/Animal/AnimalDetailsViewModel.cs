using AnimalStudio.Data.Models;

namespace AnimalStudio.Web.ViewModels.Animal
{
	public class AnimalDetailsViewModel
	{
		public int Id { get; set; }
			
		public string Name { get; set; } = null!;

		public int Age { get; set; }

		public string AnimalType { get; set; } = null!;

		public string OwnerId { get; set; } = null!;

		public string Owner { get; set; } = null!;

		public ICollection<AnimalProcedure> AnimalProcedure { get; set; } = new List<AnimalProcedure>();
	}
}
