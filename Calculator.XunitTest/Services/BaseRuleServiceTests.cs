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
public class BaseRuleServiceTests
{
        private Mock<AppDbContext> _mockContext;
        private Mock<DbSet<BaseRule>> _mockSet;
        private BaseRuleService _service;

        public BaseRuleServiceTests()
        {
            _mockSet = new Mock<DbSet<BaseRule>>();
            _mockContext = new Mock<AppDbContext>();
            _mockContext.Setup(m => m.Set<BaseRule>()).Returns(_mockSet.Object);
            _service = new BaseRuleService(_mockContext.Object);
        }

        [Fact]
        public async Task GetBaseRuleByIdAsync_ShouldReturnBaseRule_WhenExists()
        {
            // Arrange
            var expected = new BaseRule { Id = 1 };
            _mockSet.Setup(m => m.SingleOrDefaultAsync(It.IsAny<Expression<Func<BaseRule, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected);

            // Act
            var result = await _service.GetBaseRuleByIdAsync(1);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetBaseRuleByIdAsync_ShouldThrowException_WhenNotExists()
        {
            // Arrange
            _mockSet.Setup(m => m.SingleOrDefaultAsync(It.IsAny<Expression<Func<BaseRule, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((BaseRule)null);

            // Act & Assert
            await Assert.ThrowsAsync<NullReferenceException>(() => _service.GetBaseRuleByIdAsync(1));
        }

        [Fact]
        public async Task GetBaseRulesAsync_ShouldReturnAllBaseRules()
        {
            // Arrange
            var expected = new List<BaseRule> { new BaseRule(), new BaseRule() };
            _mockSet.Setup(m => m.AsNoTracking()).Returns(expected.AsQueryable());

            // Act
            var result = await _service.GetBaseRulesAsync();

            // Assert
            Assert.Equal(expected, result);
        }

        // Similar tests can be written for other methods...
    }

    //private readonly DbContextOptions<AppDbContext> _options;
    //private readonly AppDbContext _context;
    //private readonly BaseRuleService _service;
    //public BaseRuleServiceTests()
    //{
    //    _options = new DbContextOptionsBuilder<AppDbContext>()
    //        .UseInMemoryDatabase(databaseName: "MyTestDb")
    //        .Options;
    //    _context = new AppDbContext(_options);
    //    _service = new BaseRuleService(_context);
    //}


    //[Fact]
    //public async Task GetBaseRulesAsync_ShouldReturnAllBaseRules()
    //{
    //    // Arrange
    //    List<BaseRule> BaseRules =
    //    [
    //        new()
    //        {
    //            StartTime = new TimeOnly(6, 0, 0),
    //            EndTime = new TimeOnly(6, 29, 0),
    //            TaxAmount = 8,
    //            City = "Gothenburg",
    //            Country = "Sweden",
    //            MonetaryUnit = "SEK",
    //            CreatedAt = DateTime.Now,
    //            UpdatedAt = DateTime.Now,
    //        },
    //        new()
    //        {
    //            StartTime = new TimeOnly(6, 0, 0),
    //            EndTime = new TimeOnly(6, 29, 0),
    //            TaxAmount = 8,
    //            City = "Gothenburg",
    //            Country = "Sweden",
    //            MonetaryUnit = "SEK",
    //            CreatedAt = DateTime.Now,
    //            UpdatedAt = DateTime.Now,
    //        },
    //        new()
    //        {
    //            StartTime = new TimeOnly(6, 0, 0),
    //            EndTime = new TimeOnly(6, 29, 0),
    //            TaxAmount = 8,
    //            City = "Gothenburg",
    //            Country = "Sweden",
    //            MonetaryUnit = "SEK",
    //            CreatedAt = DateTime.Now,
    //            UpdatedAt = DateTime.Now,
    //        }
    //    ];

    //    _service.AddRange(BaseRules);
    //    _context.SaveChanges();

    //    // Act
    //    List<BaseRule> result = await _service.GetBaseRulesAsync();

    //    // Assert
    //    Assert.Equal(3, result.Count);
    //}

    //[Fact]
    //public async Task GetBaseRulesWithTaxesByIdsAsync_ShouldReturnBaseRuleForSpecificTime()
    //{
    //    // Arrange
    //    List<BaseRule> baseRules =
    //     [
    //         new()
    //         {
    //             Id = 13,
    //             Vehicle = VehicleType.Car,
    //             HolydayDateTime = null,
    //             DayOfWeek = null,
    //             HaveNotTax = false,
    //             City = "Gothenburg",
    //             Country = "Sweden",
    //             CreatedAt = DateTime.Now,
    //             UpdatedAt = DateTime.Now,
    //         },
    //         new()
    //         {
    //             Id = 130,
    //             Vehicle = VehicleType.Car,
    //             HolydayDateTime = new(2022, 12, 22),
    //             DayOfWeek = DayOfWeek.Tuesday,
    //             HaveNotTax = false,
    //             City = "Iran",
    //             Country = "Tehran",
    //             CreatedAt = DateTime.Now,
    //             UpdatedAt = DateTime.Now,
    //         }
    //     ];
    //    _service.AddRange(baseRules);
    //    _context.SaveChanges();

    //    IEnumerable<int> ids = new List<int>() {13,130};
    //    // Act
    //    List<BaseRule> result = await _service.GetBaseRulesWithTaxesByIdsAsync(ids);

    //    // Assert
    //    Assert.NotNull(result);
    //    //Assert.Equal(8, result.TaxAmount);
    //}

    //[Fact]
    //public async Task GetBaseRuleByIdAsync_ShouldReturnBaseRuleForSpecificId()
    //{
    //    // Arrange
    //    BaseRule baseRule = new()
    //    {
    //        Id = 101011,
    //        Vehicle = VehicleType.Bus,
    //        HolydayDateTime = null,
    //        DayOfWeek = DayOfWeek.Monday,
    //        HaveNotTax = true,
    //        City = "Gothenburg",
    //        Country = "Sweden",
    //        CreatedAt = DateTime.Now,
    //        UpdatedAt = DateTime.Now,
    //    };
    //    _service.Add(baseRule);
    //    _context.SaveChanges();

    //    // Act
    //    BaseRule result = await _service.GetBaseRuleByIdAsync(1);

    //    // Assert
    //    Assert.NotNull(result);
    //    Assert.Equal(baseRule, result);
    //}

    //[Fact]
    //public async Task GetBaseRulesByFilterAsync_ShouldReturnBaseRulesBasedOnFilter()
    //{
    //    // Arrange
    //    List<BaseRule> BaseRules =
    //    [
    //        new()
    //        { 
    //            Vehicle = VehicleType.Bus,
    //            HolydayDateTime = null,
    //            DayOfWeek = DayOfWeek.Monday,
    //            HaveNotTax = true,
    //            City = "Gothenburg",
    //            Country = "Sweden",
    //            CreatedAt = DateTime.Now,
    //            UpdatedAt = DateTime.Now,
    //        },
    //        new()
    //        { 
    //            Vehicle = VehicleType.Car,
    //            HolydayDateTime = new(2022,12,22),
    //            DayOfWeek = DayOfWeek.Tuesday,
    //            HaveNotTax = true,
    //            City = "Iran",
    //            Country = "Amol",
    //            CreatedAt = DateTime.Now,
    //            UpdatedAt = DateTime.Now,
    //        },
    //        new()
    //        { 
    //            Vehicle = VehicleType.Car,
    //            HolydayDateTime = null,
    //            DayOfWeek = null,
    //            HaveNotTax = true,
    //            City = "Gothenburg",
    //            Country = "Sweden",
    //            CreatedAt = DateTime.Now,
    //            UpdatedAt = DateTime.Now,
    //        }
    //    ];

    //    _service.AddRange(BaseRules);
    //    _context.SaveChanges();

    //    BaseRulePaginationFilter filter = new() { 
    //        City = "Amol"
    //    };

    //    // Act
    //    List<BaseRule> result = await _service.GetBaseRulesByFilterAsync(filter);

    //    // Assert
    //    Assert.Single(result);
    //}
}
