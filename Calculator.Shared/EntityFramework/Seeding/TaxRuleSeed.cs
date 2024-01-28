using Calculator.Shared.EntityFramework.Entities.TaxEntities;

namespace Calculator.Shared.EntityFramework.Seeding;
internal static class TaxRuleSeed
{
    public static List<TaxRule> All => new()
    {
        new ()
        {
            Id = 1,
            StartTime = new TimeOnly(6,0,0),
            EndTime = new TimeOnly(6,29,0),
            TaxAmount = 8,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        },
        new ()
        {
            Id = 2,
            StartTime = new TimeOnly(6,30,0),
            EndTime = new TimeOnly(6,59,0),
            TaxAmount = 13,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        },
        new()
        {
            Id = 3,
            StartTime = new TimeOnly(7,0,0),
            EndTime = new TimeOnly(7,59,0),
            TaxAmount = 18,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        },
        new ()
        {
            Id = 4,
            StartTime = new TimeOnly(8,0,0),
            EndTime = new TimeOnly(8,29,0),
            TaxAmount = 13,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        },
        new TaxRule()
        {
            Id = 5,

            StartTime = new TimeOnly(8,30,0),
            EndTime = new TimeOnly(14,59,0),
            TaxAmount = 8,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        },
        new ()
        {
            Id = 6,
            StartTime = new TimeOnly(15,0,0),
            EndTime = new TimeOnly(15,29,0),
            TaxAmount = 13,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        },
        new ()
        {
            Id = 7,
            StartTime = new TimeOnly(15,30,0),
            EndTime = new TimeOnly(16,59,0),
            TaxAmount = 18,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        },
        new ()
        {
            Id = 8,
            StartTime = new TimeOnly(17,0,0),
            EndTime = new TimeOnly(17,59,0),
            TaxAmount = 13,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        },
        new ()
        {
            Id = 9,
            StartTime = new TimeOnly(18,0,0),
            EndTime = new TimeOnly(18,29,0),
            TaxAmount = 8,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        },
        new ()
        {
            Id = 10,
            StartTime = new TimeOnly(18,30,0),
            EndTime = new TimeOnly(5,59,0),
            TaxAmount = 0,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        },
    };
}
