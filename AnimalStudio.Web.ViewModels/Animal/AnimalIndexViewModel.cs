namespace AnimalStudio.Web.ViewModels.Animal
{
	public class AnimalIndexViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public int Age { get; set; }

		public string? Owner { get; set; }

	}
}
