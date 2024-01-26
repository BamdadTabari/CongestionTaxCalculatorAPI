using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calculator.Shared.EntityFramework.Entities.TaxEntities;
public class TaxRule : BaseEntity
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string MonetaryUnit { get; set; }
    public decimal TaxAmount { get; set; }
}


public class TaxRuleEntityConfiguration : IEntityTypeConfiguration<TaxRule>
{
    public void Configure(EntityTypeBuilder<TaxRule> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(b => b.City).IsRequired();
        builder.Property(b => b.Country).IsRequired();
        builder.Property(b => b.City).IsRequired();
        builder.Property(b => b.StartTime).IsRequired();
        builder.Property(b => b.EndTime).IsRequired();
        builder.Property(b => b.TaxAmount).IsRequired().HasPrecision(18, 2); ;
    }
}
