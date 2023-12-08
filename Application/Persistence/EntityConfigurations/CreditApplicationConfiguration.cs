using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Persistence.EntityConfigurations;

public class CreditApplicationConfiguration : IEntityTypeConfiguration<CreditApplication>
{
    public void Configure(EntityTypeBuilder<CreditApplication> builder)
    {
        builder.ToTable("CreditApplication").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Id).HasColumnName("Amount").IsRequired();
        builder.Property(b => b.Id).HasColumnName("InstallmentCount").IsRequired();
        builder.Property(b => b.Id).HasColumnName("StartDate").IsRequired();
        builder.Property(b => b.Id).HasColumnName("Interest").IsRequired();
        builder.Property(b => b.Id).HasColumnName("Status").IsRequired();
        builder.Property(b => b.Id).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.Id).HasColumnName("UpdatedDate");
        builder.Property(b => b.Id).HasColumnName("DeletedDate");
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
