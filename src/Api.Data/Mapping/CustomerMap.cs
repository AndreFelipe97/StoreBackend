using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<CostumerEntity>
    {
        public void Configure(EntityTypeBuilder<CostumerEntity> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired();
            builder.Property(c => c.Phone)
                .IsRequired()
                .HasMaxLength(11);
            builder.Property(c => c.CreatedAt)
                .HasDefaultValue(DateTime.Now);
            builder.Property(c => c.UpdatedAt);
        }
    }
}
