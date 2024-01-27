using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Shared.EntityFramework.Entities.TaxEntities;
public class CalculatedTax: BaseEntity
{
    public DateTime Date { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string MonetaryUnit { get; set; }
    public decimal AmountOfDay { get; set; }
}


public class CalculatedTaxEntityConfiguration : IEntityTypeConfiguration<CalculatedTax>
{
    public void Configure(EntityTypeBuilder<CalculatedTax> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(b => b.City).IsRequired();
        builder.Property(b => b.Country).IsRequired();
        builder.Property(b => b.City).IsRequired();
        builder.Property(b => b.Date).IsRequired();
        builder.Property(b => b.AmountOfDay).IsRequired().HasPrecision(18, 2); ;
    }
}
