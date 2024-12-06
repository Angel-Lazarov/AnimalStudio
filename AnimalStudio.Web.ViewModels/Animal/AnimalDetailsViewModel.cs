using AnimalStudio.Data.Models;

namespace AnimalStudio.Web.ViewModels.Animal
{
	public class AnimalDetailsViewModel
	{
		public string Id { get; set; } = null!;

		public string Name { get; set; } = null!;

		public int Age { get; set; }

		public string AnimalType { get; set; } = null!;

		public string OwnerId { get; set; } = null!;

		public string Owner { get; set; } = null!;

		public ICollection<Data.Models.Order> Orders { get; set; } = new List<Data.Models.Order>();
	}
}
