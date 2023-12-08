using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Id).HasColumnName("Name").IsRequired();
        builder.Property(b => b.Id).HasColumnName("Surname").IsRequired();
        builder.Property(b => b.Id).HasColumnName("Email").IsRequired();
        builder.Property(b => b.Id).HasColumnName("IdNumber").IsRequired();
        builder.Property(b => b.Id).HasColumnName("Salary").IsRequired();
        builder.Property(b => b.Id).HasColumnName("Debt");
        builder.Property(b => b.Id).HasColumnName("CreditScore");
        builder.Property(b => b.Id).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.Id).HasColumnName("UpdatedDate");
        builder.Property(b => b.Id).HasColumnName("DeletedDate");
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
