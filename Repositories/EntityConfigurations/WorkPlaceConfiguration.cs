using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResumeFinder.Entities;

namespace ResumeFinder.Repositories.EntityConfigurations
{
    public class WorkPlaceConfiguration : IEntityTypeConfiguration<WorkPlace>
    {
        public void Configure(EntityTypeBuilder<WorkPlace> builder)
        {
            builder.HasKey(wp => wp.Id);
            builder.Property(wp => wp.Id).ValueGeneratedOnAdd();

            builder.Property(wp => wp.CompanyName).HasMaxLength(150);
            builder.Property(wp => wp.Description).HasMaxLength(2000);
            builder.Property(wp => wp.Level).HasConversion<string>();

            builder.HasOne(wp => wp.Specialization).WithMany().HasForeignKey(wp => wp.SpecializationId);

        }
    }
}
