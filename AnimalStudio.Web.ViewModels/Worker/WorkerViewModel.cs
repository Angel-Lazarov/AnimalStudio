using AnimalStudio.Web.ViewModels.Procedure;
using System.ComponentModel.DataAnnotations;

namespace AnimalStudio.Web.ViewModels.Worker
{
    public class WorkerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required man!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters man!")]
        public string Name { get; set; } = null!;

        public ICollection<ProcedureDetailsViewModel> Procedures { get; set; } = new List<ProcedureDetailsViewModel>();
    }
}
