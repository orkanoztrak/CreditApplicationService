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
        builder.Property(b => b.Amount).HasColumnName("Amount").IsRequired();
        builder.Property(b => b.InstallmentCount).HasColumnName("InstallmentCount").IsRequired();
        builder.Property(b => b.PaidBackIn).HasColumnName("PaidBackIn").IsRequired();
        builder.Property(b => b.Interest).HasColumnName("Interest").IsRequired();
        builder.Property(b => b.Status).HasColumnName("Status").IsRequired();
        builder.Property(b => b.StatusMessage).HasColumnName("StatusMessage").IsRequired();
        builder.Property(b => b.LinkedCustomerId).HasColumnName("LinkedCustomerId").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
    }
}
