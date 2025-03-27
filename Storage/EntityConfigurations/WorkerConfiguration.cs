using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResumeFinder.Domain.Models;

namespace ResumeFinder.Repositories.EntityConfigurations
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Id).ValueGeneratedOnAdd();

            builder.Property(w => w.Name).HasMaxLength(50);
            builder.Property(w => w.Surname).HasMaxLength(100);
            builder.Property(w => w.PhoneNumber).HasMaxLength(20);
            builder.Property(w => w.Email).HasMaxLength(150);
            builder.Property(w => w.Information).HasMaxLength(100);
            builder.Property(w => w.Gender).HasConversion<string>();

            builder.HasOne(w => w.User).WithOne().HasForeignKey<Worker>(w => w.UserId);
        }
    }
}
