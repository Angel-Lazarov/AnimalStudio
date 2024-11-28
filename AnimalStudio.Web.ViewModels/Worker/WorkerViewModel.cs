using System.ComponentModel.DataAnnotations;
using static AnimalStudio.Common.EntityValidationConstants.Worker;

namespace AnimalStudio.Web.ViewModels.Worker
{
	public class WorkerViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Name is required man!")]
		[StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters man!")]
		public string Name { get; set; } = null!;

		public string? ImageUrl { get; set; }

		[Required]
		[MaxLength(WorkerDescriptionMaxLength)]
		[MinLength(WorkerDescriptionMinLength)]
		public string Description { get; set; } = null!;
	}
}
