using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalStudio.Data.Models
{
    public class AnimalProcedure
    {
        public int AnimalId { get; set; }
        [ForeignKey(nameof(AnimalId))]
        public Animal Animal { get; set; } = null!;

        public int ProcedureId { get; set; }
        [ForeignKey(nameof(ProcedureId))]
        public Procedure Procedure { get; set; } = null!;
    }
}
