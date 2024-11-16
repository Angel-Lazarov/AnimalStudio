using AnimalStudio.Web.ViewModels.Procedure;

namespace AnimalStudio.Web.ViewModels.Worker
{
	public class WorkerDetailsViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public ICollection<ProcedureDetailsViewModel> Procedures { get; set; } = new List<ProcedureDetailsViewModel>();
	}
}
