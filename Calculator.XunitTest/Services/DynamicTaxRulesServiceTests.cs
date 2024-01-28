using Calculator.Shared.EntityFramework.Configs;
using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Infrastructure.Pagination;
using Calculator.Shared.Services.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Calculator.XunitTest.Services;
public class DynamicTaxRulesServiceTests
{
    private readonly DbContextOptions<AppDbContext> _options;
    private readonly AppDbContext _context;
    private readonly DynamicTaxRulesService _service;
    public DynamicTaxRulesServiceTests()
    {
        _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "MyTestDb")
            .Options;
        _context = new AppDbContext(_options);
        _service = new DynamicTaxRulesService(_context);
    }

    [Fact]
    public async Task GetTaxRulesAsync_ShouldReturnAllTaxRules()
    {
        // Arrange
        List<TaxRule> taxRules =
        [
            new()
            {
                //Id = 1,
                StartTime = new TimeOnly(6, 0, 0),
                EndTime = new TimeOnly(6, 29, 0),
                TaxAmount = 8,
                City = "Gothenburg",
                Country = "Sweden",
                MonetaryUnit = "SEK",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new()
            {
                //Id = 2,
                StartTime = new TimeOnly(6, 0, 0),
                EndTime = new TimeOnly(6, 29, 0),
                TaxAmount = 8,
                City = "Gothenburg",
                Country = "Sweden",
                MonetaryUnit = "SEK",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new()
            {
                //Id = 3,
                StartTime = new TimeOnly(6, 0, 0),
                EndTime = new TimeOnly(6, 29, 0),
                TaxAmount = 8,
                City = "Gothenburg",
                Country = "Sweden",
                MonetaryUnit = "SEK",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }
        ];

        _service.AddRange(taxRules);
        _context.SaveChanges();

        // Act
        List<TaxRule> result = await _service.GetTaxRulesAsync();

        // Assert
        Assert.Equal(3, result.Count);
    }

    [Fact]
    public async Task GetTaxRuleForDateAsync_ShouldReturnTaxRuleForSpecificDate()
    {
        // Arrange
        TaxRule taxRule = new()
        {
            StartTime = new TimeOnly(6, 0, 0),
            EndTime = new TimeOnly(6, 29, 0),
            TaxAmount = 8,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };
        _service.Add(taxRule);
        _context.SaveChanges();

        // Act
        TaxRule result = await _service.GetTaxRuleForTimeAsync(new TimeOnly(6, 1, 30));

        // Assert
        Assert.NotNull(result);
        Assert.Equal(8, result.TaxAmount);
    }

    [Fact]
    public async Task GetTaxRuleByIdAsync_ShouldReturnTaxRuleForSpecificId()
    {
        // Arrange
        TaxRule taxRule = new()
        {
            //Id = 1,
            StartTime = new TimeOnly(6, 0, 0),
            EndTime = new TimeOnly(6, 29, 0),
            TaxAmount = 8,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };
        _service.Add(taxRule);
        _context.SaveChanges();

        // Act
        TaxRule result = await _service.GetTaxRuleByIdAsync(1);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetTaxRulesByFilterAsync_ShouldReturnTaxRulesBasedOnFilter()
    {
        // Arrange
        List<TaxRule> taxRules =
        [
            new()
            { //Id = 1,
                StartTime = new TimeOnly(6, 0, 0),
                EndTime = new TimeOnly(6, 29, 0),
                TaxAmount = 8,
                City = "Gothenburg",
                Country = "Sweden",
                MonetaryUnit = "SEK",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new()
            { //Id = 2,
                StartTime = new TimeOnly(6, 0, 0),
                EndTime = new TimeOnly(6, 29, 0),
                TaxAmount = 8,
                City = "Gothenburg",
                Country = "Sweden",
                MonetaryUnit = "SEK",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new()
            { //Id = 3 ,
                StartTime = new TimeOnly(6, 0, 0),
                EndTime = new TimeOnly(6, 29, 0),
                TaxAmount = 8,
                City = "Gothenburg",
                Country = "Sweden",
                MonetaryUnit = "SEK",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }
        ];

        _service.AddRange(taxRules);
        _context.SaveChanges();

        DefaultPaginationFilter filter = new() { Page = 1, PageSize = 2 };

        // Act
        List<TaxRule> result = await _service.GetTaxRulesByFilterAsync(filter);

        // Assert
        Assert.Equal(2, result.Count);
    }
}

