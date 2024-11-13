using System.ComponentModel.DataAnnotations;

namespace AnimalStudio.Web.ViewModels.Procedure
{
	public class DeleteProcedureViewModel
	{
		public int Id { get; set; }

		[Required]
		public string ProcedureName { get; set; } = null!;

		//[Required]
		//public string Owner { get; set; } = null!;

		//[Required]
		//public string OwnerId { get; set; } = null!;
	}
}
