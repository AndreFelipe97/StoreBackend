using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name)
                .IsRequired();
            builder.Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(11);
            builder.HasIndex(u => u.Email)
                .IsUnique();
            builder.Property(u => u.Password)
                .IsRequired();
            builder.Property(u => u.Role)
                .IsRequired();
            builder.Property(u => u.CreatedAt)
                .HasDefaultValue(DateTime.Now);
            builder.Property(u => u.UpdatedAt);
        }
    }
}
