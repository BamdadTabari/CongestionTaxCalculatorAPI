using AutoMapper;
using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Infrastructure.Pagination;
using Calculator.Shared.Models.DataTransferObjects;
using Calculator.Shared.Services.BaseAndConfigs;
using CongestionTaxCalculator.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Calculator.XunitTest.Controllers;
public class TaxRulesControllerTests
{
    protected readonly Mock<IUnitOfWork> _mockUnitOfWork;
    protected readonly Mock<IMapper> _mockMapper;
    protected readonly TaxRulesController _controller;

    public TaxRulesControllerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _controller = new TaxRulesController(_mockUnitOfWork.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetTaxRuleByIdAsyncTest_ReturnsOkResultWithCorrectTaxRule()
    {
        // Arrange
        int id = 1;
        TaxRule taxRule = new();
        _mockUnitOfWork.Setup(uow => uow.TaxRules.GetTaxRuleByIdAsync(id)).ReturnsAsync(taxRule);
        TaxRuleDto taxRuleDto = new();
        _mockMapper.Setup(m => m.Map<TaxRuleDto>(taxRule)).Returns(taxRuleDto);

        // Act
        IActionResult result = await _controller.GetTaxRuleByIdAsync(id);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        TaxRuleDto returnedTaxRule = Assert.IsType<TaxRuleDto>(okResult.Value);
        Assert.Equal(taxRuleDto, returnedTaxRule);
    }



    [Fact]
    public async Task GetTaxRulesAsyncTest_ReturnsOkResultWithCorrectTaxRules()
    {
        // Arrange
        List<TaxRule> taxRules = [new()];
        _mockUnitOfWork.Setup(uow => uow.TaxRules.GetTaxRulesAsync()).ReturnsAsync(taxRules);
        List<TaxRuleDto> taxRuleDtos = [new()];
        _mockMapper.Setup(m => m.Map<List<TaxRuleDto>>(taxRules)).Returns(taxRuleDtos);

        // Act
        IActionResult result = await _controller.GetTaxRulesAsync();

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        List<TaxRuleDto> returnedTaxRules = Assert.IsType<List<TaxRuleDto>>(okResult.Value);
        Assert.Equal(taxRuleDtos, returnedTaxRules);
    }



    [Fact]
    public async Task CreateTaxRuleTest_ReturnsOkResultWithCreatedTaxRule()
    {
        // Arrange
        TaxRuleDto taxRuleDto = new();
        TaxRule taxRule = new();
        _mockMapper.Setup(m => m.Map<TaxRule>(taxRuleDto)).Returns(taxRule);
        _mockUnitOfWork.Setup(uow => uow.TaxRules.AddAsync(taxRule)).Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(uow => uow.CommitAsync()).ReturnsAsync(true);

        // Act
        IActionResult result = await _controller.CreateTaxRule(taxRuleDto);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        TaxRule returnedTaxRule = Assert.IsType<TaxRule>(okResult.Value);
        Assert.Equal(taxRule, returnedTaxRule);
    }



    [Fact]
    public async Task UpdateTaxRoleTest_ReturnsOkResultWithUpdatedTaxRule()
    {
        // Arrange
        int id = 1;
        TaxRuleDto taxRuleDto = new();
        TaxRule taxRule = new();
        _mockMapper.Setup(m => m.Map<TaxRule>(taxRuleDto)).Returns(taxRule);
        _mockUnitOfWork.Setup(uow => uow.TaxRules.ExistsAsync(id)).ReturnsAsync(true);
        _mockUnitOfWork.Setup(uow => uow.TaxRules.Update(taxRule));
        _mockUnitOfWork.Setup(uow => uow.CommitAsync()).ReturnsAsync(true);

        // Act
        IActionResult result = await _controller.UpdateTaxRole(id, taxRuleDto);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        TaxRule returnedTaxRule = Assert.IsType<TaxRule>(okResult.Value);
        Assert.Equal(taxRule, returnedTaxRule);
    }

    [Fact]
    public async Task DeleteTaxRoleTest_ReturnsOkResultWithDeletedTaxRule()
    {
        // Arrange
        int id = 1;
        _mockUnitOfWork.Setup(uow => uow.TaxRules.ExistsAsync(id)).ReturnsAsync(true);
        _mockUnitOfWork.Setup(uow => uow.TaxRules.Remove(It.IsAny<TaxRule>())).Verifiable();
        _mockUnitOfWork.Setup(uow => uow.CommitAsync()).ReturnsAsync(true);

        // Act
        IActionResult result = await _controller.DeleteTaxRole(id);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        string message = Assert.IsType<string>(okResult.Value);
        Assert.Contains(id.ToString(), message);
        _mockUnitOfWork.Verify();
    }

    [Fact]
    public async Task GetTaxRolesByFilterTest_ReturnsOkResultWithCorrectTaxRules()
    {
        // Arrange
        DefaultPaginationFilter filter = new();
        List<TaxRule> taxRules = [new()];
        _mockUnitOfWork.Setup(uow => uow.TaxRules.GetTaxRulesByFilterAsync(filter)).ReturnsAsync(taxRules);
        List<TaxRuleDto> taxRuleDtos = [new()];
        _mockMapper.Setup(m => m.Map<List<TaxRuleDto>>(taxRules)).Returns(taxRuleDtos);

        // Act
        IActionResult result = await _controller.GetTaxRolesByFilter(filter);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        PaginatedList<TaxRuleDto> returnedTaxRules = Assert.IsType<PaginatedList<TaxRuleDto>>(okResult.Value);
        Assert.Equal(taxRuleDtos, returnedTaxRules.Data);
    }
}