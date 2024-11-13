using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		[MaxLength(ProcedureDescriptionMaxLength)]
		public string Description { get; set; } = null!;

		[Required]
        [Column(TypeName = PriceColumnTypeName)]
        public decimal Price { get; set; }

        [Required]
        public int WorkerId { get; set; }
    }
}
