using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Report.Core.Entities;

namespace Report.Infrastructure.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Login).IsRequired().HasMaxLength(50);
            builder.Property(p => p.PasswordHash).IsRequired();
            builder.HasMany(p => p.Records).WithOne(p => p.User).HasForeignKey(k => k.UserId);
        }

    }
}