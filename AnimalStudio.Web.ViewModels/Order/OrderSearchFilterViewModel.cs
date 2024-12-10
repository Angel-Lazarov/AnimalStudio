namespace AnimalStudio.Web.ViewModels.Order
{
	public class OrderSearchFilterViewModel
	{
		public IEnumerable<OrderIndexViewModel>? Orders { get; set; }

		public string? SearchQuery { get; set; }

		public string? ProcedureFilter { get; set; }

		public IEnumerable<string>? AllProcedures { get; set; }

		public string? AnimalTypeFilter { get; set; }

		public IEnumerable<string>? AllAnimalTypes { get; set; }

		public int? CurrentPage { get; set; } = 1;

		public int? EntitiesPerPage { get; set; } = 3;

		public int? TotalPages { get; set; }
	}
}
