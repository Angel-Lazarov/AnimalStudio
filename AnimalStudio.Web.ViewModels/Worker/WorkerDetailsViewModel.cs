using AnimalStudio.Web.ViewModels.Procedure;
using System.ComponentModel.DataAnnotations;
using static AnimalStudio.Common.EntityValidationConstants.Worker;

namespace AnimalStudio.Web.ViewModels.Worker
{
	public class WorkerDetailsViewModel
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[MinLength(WorkerNameMinLength)]
		[MaxLength(WorkerNameMaxLength)]
		public string Name { get; set; } = null!;

		public string? ImageUrl { get; set; }

		[Required]
		[MaxLength(WorkerDescriptionMaxLength)]
		[MinLength(WorkerDescriptionMinLength)]
		public string Description { get; set; } = null!;

		public ICollection<ProcedureDetailsViewModel> Procedures { get; set; } = new List<ProcedureDetailsViewModel>();
	}
}
