using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResumeFinder.Domain.Models;

namespace ResumeFinder.Storage.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Id).ValueGeneratedOnAdd();

            builder.Property(w => w.Name).HasMaxLength(50);
            builder.Property(w => w.Surname).HasMaxLength(100);
            builder.Property(w => w.PhoneNumber).HasMaxLength(20);
            builder.Property(w => w.Email).HasMaxLength(150);
            builder.Property(w => w.CompanyName).HasMaxLength(150);
        }
    }
}
