using AnimalStudio.Web.ViewModels.Worker;

namespace AnimalStudio.Web.ViewModels.Procedure
{
	public class ProcedureDetailsViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public decimal Price { get; set; }

		public string Description { get; set; } = null!;

		public ICollection<WorkerViewModel> Workers { get; set; } = new List<WorkerViewModel>();
	}
}
