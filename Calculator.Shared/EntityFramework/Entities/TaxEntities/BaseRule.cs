using Calculator.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calculator.Shared.EntityFramework.Entities.TaxEntities;
public class BaseRule : BaseEntity<int>
{
    public VehicleType? Vehicle { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
    public DateTime? HolydayDateTime { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public bool HaveNotTax { get; set; }

}

public class BaseRuleEntityConfiguration : IEntityTypeConfiguration<BaseRule>
{
    public void Configure(EntityTypeBuilder<BaseRule> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(b => b.Country).IsRequired();
        builder.Property(b => b.City).IsRequired();
        builder.Property(b => b.HaveNotTax).IsRequired().HasDefaultValue(true);
    }
}