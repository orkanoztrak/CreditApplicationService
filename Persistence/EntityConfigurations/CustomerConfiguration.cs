using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;

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

    /*public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string IdNumber { get; set; }
    public int Salary { get; set; }
    public int Debt { get; set; }
    public int CreditScore { get; set; }*/

}

}
