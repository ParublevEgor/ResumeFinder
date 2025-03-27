using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResumeFinder.Domain.Models;

namespace ResumeFinder.Repositories.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.Login).HasMaxLength(100);
            builder.Property(u => u.PasswordHash).HasMaxLength(256);

            builder.Property(u => u.Role).HasConversion<string>();
        }
    }
}
