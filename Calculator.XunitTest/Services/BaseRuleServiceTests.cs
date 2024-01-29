using Calculator.Shared.EntityFramework.Configs;
using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Enums;
using Calculator.Shared.Infrastructure.Pagination;
using Calculator.Shared.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.XunitTest.Services;
// ok here I Sayed let have new experience in unit tests so Run Just This Class
// And see The code And Think About it Why All test some times passed and some times failed :D
public class BaseRuleServiceTests
{
    private readonly DbContextOptions<AppDbContext> _options;
    private readonly AppDbContext _context;
    private readonly BaseRuleService _service;

    public BaseRuleServiceTests()
    {
        _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "MyTestDb")
            .Options;
        _context = new AppDbContext(_options);
        _service = new BaseRuleService(_context);
    }

    [Fact]
    public async Task GetBaseRuleByIdAsync_ShouldReturnBaseRule_WhenExists()
    {
        // Arrange
        BaseRule baseRule = new()
        {
            Id = 666,
            HaveNotTax = false,
            Country = "USA",
            City = "New York",
            Vehicle = VehicleType.Motorbike,
            DayOfWeek = DayOfWeek.Sunday,
            HolydayDateTime = null
        };
        _service.Add(baseRule);
        _context.SaveChanges();

        // Act
        BaseRule result = await _service.GetBaseRuleByIdAsync(666);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(666, result.Id);
    }

    [Fact]
    public async Task GetBaseRulesAsync_ShouldReturnAllBaseRules()
    {
        // Arrange
        List<BaseRule> baseRules = [
             new()
             {
                 HaveNotTax = false,
                 Country = "USA",
                 City = "New York",
                 Vehicle = VehicleType.Motorbike,
                 DayOfWeek = DayOfWeek.Sunday,
                 HolydayDateTime = null
             },
            new()
            {
                HaveNotTax = true,
                Country = "USA",
                City = "L.A",
                Vehicle = VehicleType.Bus,
                DayOfWeek = DayOfWeek.Saturday,
                HolydayDateTime = null
            },
        ];


        _service.AddRange(baseRules);
        _context.SaveChanges();

        // Act
        List<BaseRule> result = await _service.GetBaseRulesAsync();

        // Assert
        Assert.Equal(7, result.Count);
    }

    [Fact]
    public async Task GetBaseRulesByFilterAsync_ShouldReturnFilteredBaseRules()
    {
        // Arrange
        List<BaseRule> baseRules = [
             new()
             {
                 HaveNotTax = false,
                 Country = "USA",
                 City = "New York",
                 Vehicle = VehicleType.Motorbike,
                 DayOfWeek = DayOfWeek.Sunday,
                 HolydayDateTime = null
             },
            new()
            {
                HaveNotTax = false,
                Country = "USA",
                City = "L.A",
                Vehicle = VehicleType.Bus,
                DayOfWeek = DayOfWeek.Saturday,
                HolydayDateTime = null
            },
        ];
        _service.AddRange(baseRules);
        _context.SaveChanges();

        BaseRulePaginationFilter filter = new() { Page = 1, PageSize = 1 , City = "L.A"};

        // Act
        List<BaseRule> result = await _service.GetBaseRulesByFilterAsync(filter);

        // Assert
        Assert.Single(result);
    }

    [Fact]
    public async Task GetBaseRulesWithTaxesByIdsAsync_ShouldReturnBaseRulesWithTaxes()
    {
        // Arrange
        List<BaseRule> baseRules = [
             new()
             {
                 Id = 22,
                 HaveNotTax = false,
                 Country = "USA",
                 City = "New York",
                 Vehicle = VehicleType.Motorbike,
                 DayOfWeek = DayOfWeek.Sunday,
                 HolydayDateTime = null
             },
            new()
            {
                Id = 32,
                HaveNotTax = false,
                Country = "USA",
                City = "L.A",
                Vehicle = VehicleType.Bus,
                DayOfWeek = DayOfWeek.Saturday,
                HolydayDateTime = null
            },
        ];
        _service.AddRange(baseRules);
        _context.SaveChanges();

        IEnumerable<int> ids = new List<int> { 32,22 };

        // Act
        List<BaseRule> result = await _service.GetBaseRulesWithTaxesByIdsAsync(ids);

        // Assert
        Assert.Equal(22, result[0].Id);
    }

    [Fact]
    public async Task GetBaseRulesByContryAndCityAsync_ShouldReturnBaseRulesByCountryAndCity()
    {
        // Arrange
        List<BaseRule> baseRules = [
             new()
             {
                 HaveNotTax = false,
                 Country = "USA",
                 City = "New York",
                 Vehicle = VehicleType.Motorbike,
                 DayOfWeek = DayOfWeek.Sunday,
                 HolydayDateTime = null
             },
            new()
            {
                HaveNotTax = true,
                Country = "USA",
                City = "L.A",
                Vehicle = VehicleType.Bus,
                DayOfWeek = DayOfWeek.Saturday,
                HolydayDateTime = null
            },
        ];
        _service.AddRange(baseRules);
        _context.SaveChanges();

        // Act
        List<BaseRule> result = await _service.GetBaseRulesByContryAndCityAsync("USA", "New York");

        // Assert
        Assert.NotNull(result);
    }


}

