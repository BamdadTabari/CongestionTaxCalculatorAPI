using Calculator.Shared.EntityFramework.Configs;
using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Enums;
using Calculator.Shared.Infrastructure.Pagination;
using Calculator.Shared.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.InMemory;
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
                StartTime = new DateTime(2013, 1, 10, 6, 0, 0),
                EndTime = new DateTime(2013, 1, 10, 6, 29, 0),
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
                StartTime = new DateTime(2013, 1, 10, 6, 0, 0),
                EndTime = new DateTime(2013, 1, 10, 6, 29, 0),
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
                StartTime = new DateTime(2013, 1, 10, 6, 0, 0),
                EndTime = new DateTime(2013, 1, 10, 6, 29, 0),
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
        TaxRule taxRule = new() { StartTime = DateTime.Now.AddDays(-1), EndTime = DateTime.Now.AddDays(1),
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
        TaxRule result = await _service.GetTaxRuleForDateAsync(DateTime.Now);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetTaxRuleByIdAsync_ShouldReturnTaxRuleForSpecificId()
    {
        // Arrange
        TaxRule taxRule = new () {
            //Id = 1,
            StartTime = new DateTime(2013, 1, 10, 6, 0, 0),
            EndTime = new DateTime(2013, 1, 10, 6, 29, 0),
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
            new() { //Id = 1,
            StartTime = new DateTime(2013,1,10,6,0,0),
            EndTime = new DateTime(2013,1,10,6,29,0),
            TaxAmount = 8,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now, },
            new() { //Id = 2,
            StartTime = new DateTime(2013,1,10,6,0,0),
            EndTime = new DateTime(2013,1,10,6,29,0),
            TaxAmount = 8,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now, },
            new() { //Id = 3 ,
            StartTime = new DateTime(2013,1,10,6,0,0),
            EndTime = new DateTime(2013,1,10,6,29,0),
            TaxAmount = 8,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,}
        ];

        _service.AddRange(taxRules);
        _context.SaveChanges();

        DefaultPaginationFilter filter = new () { Page = 1, PageSize = 2 };

        // Act
        List<TaxRule> result = await _service.GetTaxRulesByFilterAsync(filter);

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void IsItTollFreeDay_ShouldReturnTrueIfItIsTollFreeDay()
    {
        // Arrange
        DateTime date = new (2013, 1, 1);

        // Act
        bool result = _service.IsItTollFreeDay(date);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsTollFreeVehicle_ShouldReturnTrueIfVehicleIsTollFree()
    {
        // Arrange
        VehicleType vehicleType = VehicleType.Motorbike;

        // Act
        bool result = _service.IsTollFreeVehicle(vehicleType);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task CalculateTotalFeeAsync_ShouldCalculateTotalFeeForGivenDatesAndVehicle()
    {
        // Arrange
        VehicleType vehicle = VehicleType.Motorbike;
        DateTime[] dates = { DateTime.Now, DateTime.Now.AddDays(1) };
        DateTime intervalStart = DateTime.Now;

        // Act
        int result = await _service.CalculateTotalFeeAsync(vehicle, dates, intervalStart);

        // Assert
        Assert.True(result >= 0);
    }

    [Fact]
    public async Task GetTollFeeAsync_ShouldReturnTollFeeForGivenDateAndVehicle()
    {
        // Arrange
        DateTime date = DateTime.Now;
        VehicleType vehicle = VehicleType.Motorbike;

        // Act
        int result = await _service.GetTollFeeAsync(date, vehicle);

        // Assert
        Assert.True(result >= 0);
    }
}

