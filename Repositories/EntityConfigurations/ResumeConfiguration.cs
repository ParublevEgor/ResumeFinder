using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResumeFinder.Entities;

namespace ResumeFinder.Repositories.EntityConfigurations
{
    public class ResumeConfiguration : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.Name).HasMaxLength(50);

            builder.HasOne(r => r.Specialization).WithMany().HasForeignKey(r => r.SpecializationId);

            builder.HasOne(r => r.Worker).WithMany(w => w.Resumes).HasForeignKey(r => r.WorkerId);

            builder.HasMany(r => r.WorkPlaces).WithOne().HasForeignKey(w => w.ResumeId);
        }
    }
}
