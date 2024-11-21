using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AnimalStudio.Common.EntityValidationConstants.Procedure;

namespace AnimalStudio.Web.ViewModels.Procedure
{
    public class AddProcedureFormModel
    {
        [Required]
        [StringLength(ProcedureNameMaxLength, MinimumLength = ProcedureNameMinLength, ErrorMessage = "ProcedureName name mast be minimum 5 characters long")]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(ProcedureNameMinLength)]
        [MaxLength(ProcedureDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Column(TypeName = PriceColumnTypeName)]
        public decimal Price { get; set; }
    }
}
