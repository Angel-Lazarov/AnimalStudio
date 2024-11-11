using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalStudio.Web.ViewModels
{
	public class ProcedureViewModel
	{
		public int Id { get; set; }

		[Required]
		[StringLength(80, MinimumLength = 5, ErrorMessage = "Procedure name mast be minimum 5 characters long")]
		public string Name { get; set; } = null!;

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Price { get; set; }

		[Required]
		public int WorkerId { get; set; }
	}

}
