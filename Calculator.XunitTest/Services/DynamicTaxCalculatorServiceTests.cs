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

namespace Calculator.XunitTest.Services;
public class DynamicTaxCalculatorServiceTests
{
    private readonly DbContextOptions<AppDbContext> _options;
    private readonly AppDbContext _context;
    private readonly DynamicTaxCalculator _service;

    public DynamicTaxCalculatorServiceTests()
    {
        _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "MyTestDb")
            .Options;
        _context = new AppDbContext(_options);
        _service = new DynamicTaxCalculator(_context);
    }

    [Fact]
    public async Task GetCalculatedTaxByIdAsync_ShouldReturnCalculatedTax_WhenExists()
    {
        // Arrange
        CalculatedTax calculatedTax = new()
        {
            Id = 1,
            Date = DateTime.Now,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            AmountOfDay = 100,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };
        _service.Add(calculatedTax);
        _context.SaveChanges();

        // Act
        CalculatedTax result = await _service.GetCalculatedTaxByIdAsync(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public async Task GetCalculatedTaxesAsync_ShouldReturnAllCalculatedTaxes()
    {
        // Arrange
        List<CalculatedTax> calculatedTaxes = [
            new()
            {
                Date = DateTime.Now,
                City = "Stockholm",
                Country = "Sweden",
                MonetaryUnit = "SEK",
                AmountOfDay = 200,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new()
            {
                Date = DateTime.Now,
                City = "Gothenburg",
                Country = "Sweden",
                MonetaryUnit = "SEK",
                AmountOfDay = 100,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
        ];

        _service.AddRange(calculatedTaxes);
        _context.SaveChanges();

        // Act
        List<CalculatedTax> result = await _service.GetCalculatedTaxesAsync();

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetCalculatedTaxesByFilterAsync_ShouldReturnFilteredCalculatedTaxes()
    {
        // Arrange
        List<CalculatedTax> calculatedTaxes = [
           new()
           {
               Date = DateTime.Now,
               City = "Stockholm",
               Country = "Sweden",
               MonetaryUnit = "SEK",
               AmountOfDay = 200,
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now,
           },
            new()
            {
                Date = DateTime.Now,
                City = "Gothenburg",
                Country = "Sweden",
                MonetaryUnit = "SEK",
                AmountOfDay = 100,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
        ];

        _service.AddRange(calculatedTaxes);
        _context.SaveChanges();

        DefaultPaginationFilter filter = new() { Page = 1, PageSize = 1 };

        // Act
        List<CalculatedTax> result = await _service.GetCalculatedTaxesByFilterAsync(filter);

        // Assert
        Assert.Single(result);
    }

    [Fact]
    public async Task GetCalculatedTaxForDateTimeAsync_ShouldReturnCalculatedTaxForSpecificDate()
    {
        // Arrange
        CalculatedTax calculatedTax = new()
        {
            Id = 1,
            Date = DateTime.Now,
            City = "Gothenburg",
            Country = "Sweden",
            MonetaryUnit = "SEK",
            AmountOfDay = 100,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
        };
        _service.Add(calculatedTax);
        _context.SaveChanges();

        // Act
        CalculatedTax result = await _service.GetCalculatedTaxForDateTimeAsync(DateTime.Now);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public void IsItTollFreeDay_ShouldReturnTrue_WhenItIsTollFreeDay()
    {
        // Arrange
        DateTime date = new DateTime(2013, 1, 1);

        // Act
        bool result = _service.IsItTollFreeDay(date);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsTollFreeVehicle_ShouldReturnTrue_WhenVehicleIsTollFree()
    {
        // Arrange
        VehicleType vehicleType = VehicleType.Motorbike;

        // Act
        bool result = _service.IsTollFreeVehicle(vehicleType);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task CalculateTotalFeeForDateTimesAsync_ShouldReturnTotalFee_WhenDatesAreProvided()
    {
        // Arrange
        VehicleType vehicle = VehicleType.Motorbike;
        DateTime[] dates = [DateTime.Now, DateTime.Now.AddDays(1)];
        DateTime intervalStart = DateTime.Now;

        // Act
        decimal result = await _service.CalculateTotalFeeForDateTimesAsync(vehicle, dates, intervalStart);

        // Assert
        Assert.True(result >= 0);
    }

}
