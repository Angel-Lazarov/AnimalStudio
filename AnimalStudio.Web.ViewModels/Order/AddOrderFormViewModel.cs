using AnimalStudio.Web.ViewModels.Animal;
using AnimalStudio.Web.ViewModels.Procedure;
using System.ComponentModel.DataAnnotations;

namespace AnimalStudio.Web.ViewModels.Order
{
	public class AddOrderFormViewModel
	{
		[Required]
		public int AnimalId { get; set; }

		public IEnumerable<AnimalIndexViewModel> Animals { get; set; } = new List<AnimalIndexViewModel>();

		[Required]
		public int ProcedureId { get; set; }

		public IEnumerable<ProcedureIndexViewModel> Procedures { get; set; } = new List<ProcedureIndexViewModel>();

		[Required]
		public string UserId { get; set; } = null!;
    }
}
