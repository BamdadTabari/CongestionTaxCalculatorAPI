using Calculator.Shared.EntityFramework.Entities.TaxEntities;

namespace Calculator.Shared.EntityFramework.Seeding;
internal static class TaxRuleSeed
{
    public static List<TaxRule> All => new()
    {
        new ()
        {
            Id = 1,
            // I just choose 2013,1,10 by random because it was not holiday or weekend
            StartTime = new DateTime(2013,1,10,6,0,0),
            EndTime = new DateTime(2013,1,10,6,29,0),
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
            // I just choose 2013,1,10 by random because it was not holiday or weekend
            StartTime = new DateTime(2013,1,10,6,30,0),
            EndTime = new DateTime(2013,1,10,6,59,0),
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
            // I just choose 2013,1,10 by random because it was not holiday or weekend
            StartTime = new DateTime(2013,1,10,7,0,0),
            EndTime = new DateTime(2013,1,10,7,59,0),
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
            // I just choose 2013,1,10 by random because it was not holiday or weekend
            StartTime = new DateTime(2013,1,10,8,0,0),
            EndTime = new DateTime(2013,1,10,8,29,0),
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
            // I just choose 2013,1,10 by random because it was not holiday or weekend
            StartTime = new DateTime(2013,1,10,8,30,0),
            EndTime = new DateTime(2013,1,10,14,59,0),
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
            // I just choose 2013,1,10 by random because it was not holiday or weekend
            StartTime = new DateTime(2013,1,10,15,0,0),
            EndTime = new DateTime(2013,1,10,15,29,0),
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
            // I just choose 2013,1,10 by random because it was not holiday or weekend
            StartTime = new DateTime(2013,1,10,15,30,0),
            EndTime = new DateTime(2013,1,10,16,59,0),
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
            // I just choose 2013,1,10 by random because it was not holiday or weekend
            StartTime = new DateTime(2013,1,10,17,0,0),
            EndTime = new DateTime(2013,1,10,17,59,0),
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
            // I just choose 2013,1,10 by random because it was not holiday or weekend
            StartTime = new DateTime(2013,1,10,18,0,0),
            EndTime = new DateTime(2013,1,10,18,29,0),
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
            // I just choose 2013,1,10 by random because it was not holiday or weekend
            StartTime = new DateTime(2013,1,10,18,30,0),
            EndTime = new DateTime(2013,1,10,5,59,0),
            TaxAmount = 0,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        },
    };
}
