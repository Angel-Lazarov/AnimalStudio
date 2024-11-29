using AnimalStudio.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static AnimalStudio.Common.EntityValidationConstants.Manager;

namespace AnimalStudio.Data.Configuration
{
    internal class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(m=>m.UserId)
                .HasMaxLength(ManagerOwnerIdMaxLength)
                .IsRequired();

            builder.Property(m=>m.NickName)
                .HasMaxLength(ManagerNickNameMaxLength)
                .IsRequired();

            builder
                .HasOne(m => m.User)
                .WithOne()
                .HasForeignKey<Manager>(m => m.UserId);
        }
    }
}
