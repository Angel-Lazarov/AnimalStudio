using System.ComponentModel.DataAnnotations;
using static AnimalStudio.Common.EntityValidationConstants.Worker;

namespace AnimalStudio.Web.ViewModels.Worker
{
	public class WorkerCheckBoxInputModel
	{
		[Required]
		public int Id { get; set; }

		[Required]
		[MinLength(WorkerNameMinLength)]
		[MaxLength(WorkerNameMaxLength)]
		public string Name { get; set; } = null!;

		public bool IsSelected { get; set; }
	}
}