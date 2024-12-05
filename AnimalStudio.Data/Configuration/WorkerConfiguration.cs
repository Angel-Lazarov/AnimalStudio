using AnimalStudio.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalStudio.Data.Configuration
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder
                .Property(w => w.IsDeleted)
                .IsRequired();

            builder.HasData(this.SeedWorkers());
        }

        private IEnumerable<Worker> SeedWorkers()
        {
            List<Worker> workers = new List<Worker>
            {
                new Worker { Id = 1, Name = "Alan Jakson", ImageUrl = "/img/workers/Alan_Jakson.jpg", Description = "Dr. Alan Jakson is a skilled veterinarian with years of training and experience in animal wellness, dedicated to making every pet feel their best at our Animal Studio."},
                new Worker { Id = 2, Name = "Ana Lucia", ImageUrl = "/img/workers/Ana_Lucia.jpg", Description = "With a strong background in animal care, Dr. Ana Lucia combines expertise and compassion to offer top-tier treatments at our Animal Studio."},
                new Worker { Id = 3, Name = "Ben White", ImageUrl = "/img/workers/Ben_White.jpg", Description = "Dr. Ben White, an experienced veterinarian, brings a wealth of knowledge and hands-on experience to our Animal Studio, ensuring the utmost comfort and healing for every pet."},
                new Worker { Id = 4, Name = "Debora Browning", ImageUrl = "/img/workers/Debora_Browning.jpg", Description = "Passionate about animal health, Dr. Debora Browning is an expert with extensive training who ensures that each visit to our Animal Studio is a soothing and therapeutic experience."},
                new Worker { Id = 5, Name = "Dru Bening", ImageUrl = "/img/workers/Dru_Bening.jpg", Description = "As a dedicated professional, Dr. Dru Bening provides expert veterinary care with years of practice and a deep understanding of animal needs at our Animal Studio."},
                new Worker { Id = 6, Name = "Haris Young", ImageUrl = "/img/workers/Haris_Young.jpg", Description = "Dr. Haris Young combines years of veterinary training and real-world experience to deliver exceptional care, making pets feel cared for and pampered."},
                new Worker { Id = 7, Name = "Jake Nikson", ImageUrl = "/img/workers/Jake_Nikson.jpg", Description = "With a rich background in animal health and well-being, Dr. Jake Nikson brings skill and dedication to every treatment at our Animal Studio."},
                new Worker { Id = 8, Name = "Kate Smith", ImageUrl = "/img/workers/Kate_Smith.jpg", Description = "Dr. Kate Smith is a committed veterinarian whose extensive experience ensures pets receive the highest standard of care and comfort during every visit."},
                new Worker { Id = 9, Name = "Lili Palmer", ImageUrl = "/img/workers/Lili_Palmer.jpg", Description = "A veterinarian with years of hands-on experience, Dr. Lili Palmer offers tailored treatments that prioritize each pet’s comfort and health at our Animal Studio"},
                new Worker { Id = 10, Name = "Rahit Mazin", ImageUrl = "/img/workers/Rahit_Mazin.jpg", Description = "Dr. Rahit Mazin is an experienced veterinary professional who pairs his/her vast training with a love for animals, creating a welcoming and healing environment at our Animal Studio."},
                new Worker { Id = 11, Name = "Stefan Duglas", ImageUrl = "", Description = "With significant training and a deep understanding of animal wellness, Dr. Stefan_Duglas delivers expert care and treatments that make every pet feel their best."}
            };

            return workers;
        }
    }

}
