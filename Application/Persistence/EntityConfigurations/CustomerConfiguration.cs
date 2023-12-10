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
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.Surname).HasColumnName("Surname").IsRequired();
        builder.Property(b => b.Email).HasColumnName("Email").IsRequired();
        builder.Property(b => b.IdNumber).HasColumnName("IdNumber").IsRequired();
        builder.Property(b => b.Salary).HasColumnName("Salary").IsRequired();
        builder.Property(b => b.Debt).HasColumnName("Debt");
        builder.Property(b => b.CreditScore).HasColumnName("CreditScore");
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
    }
}
