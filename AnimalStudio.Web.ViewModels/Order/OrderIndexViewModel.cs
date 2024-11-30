namespace AnimalStudio.Web.ViewModels.Order
{
	public class OrderIndexViewModel
	{
		public Guid Id { get; set; }

		public string AnimalName { get; set; } = null!;

		public string ProcedureName { get; set; } = null!;

		public string UserId { get; set; } = null!;

		public string Owner { get; set; } = null!;

		public decimal Price { get; set; }

	}
}
