using AnimalStudio.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalStudio.Data.Configuration
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {

            builder.HasData(this.SeedWorkers());
        }

        private IEnumerable<Worker> SeedWorkers()
        {
            List<Worker> workers = new List<Worker>
            {
                new Worker { Id = 1, Name = "John Doe" },
                new Worker { Id = 2, Name = "Jane Smith" },
                new Worker { Id = 3, Name = "Alex Johnson" },
                new Worker { Id = 4, Name = "Emily Davis" },
                new Worker { Id = 5, Name = "Michael Brown" },
                new Worker { Id = 6, Name = "Sarah Wilson" },
                new Worker { Id = 7, Name = "David Lee" },
                new Worker { Id = 8, Name = "Laura Garcia" },
                new Worker { Id = 9, Name = "Chris Martin" },
                new Worker { Id = 10, Name = "Anna Thompson" }
            };

            return workers;
        }
    }

}
