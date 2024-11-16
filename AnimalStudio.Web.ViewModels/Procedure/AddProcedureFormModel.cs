using AnimalStudio.Web.ViewModels.Worker;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AnimalStudio.Common.EntityValidationConstants.Procedure;

namespace AnimalStudio.Web.ViewModels.Procedure
{
	public class AddProcedureFormModel
	{
		public int Id { get; set; }

		[Required]
		[StringLength(ProcedureNameMaxLength, MinimumLength = ProcedureNameMinLength, ErrorMessage = "Procedure name mast be minimum 5 characters long")]
		public string Name { get; set; } = null!;

		[Required]
		[MinLength(ProcedureNameMinLength)]
		[MaxLength(ProcedureDescriptionMaxLength)]
		public string Description { get; set; } = null!;

		[Required]
		[Column(TypeName = PriceColumnTypeName)]
		public decimal Price { get; set; }

		[Required]
		public int WorkerId { get; set; }

		public IEnumerable<WorkerViewModel> Workers { get; set; } = new List<WorkerViewModel>();
	}
}
