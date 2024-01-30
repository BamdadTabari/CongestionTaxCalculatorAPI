using AutoMapper;
using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Infrastructure.Pagination;
using Calculator.Shared.Models.DataTransferObjects;
using Calculator.Shared.Services.BaseAndConfigs;
using CongestionTaxCalculator.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Calculator.XunitTest.Controllers;
public class BaseRuleControllerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMapper> _mockMapper;
    private readonly BaseRuleController _controller;

    public BaseRuleControllerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _controller = new BaseRuleController(_mockUnitOfWork.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetBaseRuleByIdAsync_ReturnsOkResultWithCorrectBaseRule()
    {
        int id = 1;
        BaseRule baseRule = new();
        _mockUnitOfWork.Setup(uow => uow.BaseRules.GetBaseRuleByIdAsync(id)).ReturnsAsync(baseRule);

        // Act
        IActionResult result = await _controller.GetBaseRuleByIdAsync(id);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        BaseRuleDto returnedBaseRule = Assert.IsType<BaseRuleDto>(okResult.Value);
        Assert.Equal(baseRule.Id, returnedBaseRule.Id);
    }

    [Fact]
    public async Task GetBaseRulesAsync_ReturnsOkResultWithCorrectBaseRules()
    {
        // Arrange
        List<BaseRule> baseRules = [new BaseRule()];
        List<BaseRuleDto> baseRuleDtos = _mockMapper.Object.Map<List<BaseRuleDto>>(baseRules);
        _mockUnitOfWork.Setup(uow => uow.BaseRules.GetBaseRulesAsync()).ReturnsAsync(baseRules);

        // Act
        IActionResult result = await _controller.GetBaseRulesAsync();

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        List<BaseRuleDto> returnedBaseRules = Assert.IsType<List<BaseRuleDto>>(okResult.Value);
        Assert.True(returnedBaseRules.SequenceEqual(baseRuleDtos));
    }

    [Fact]
    public async Task CreateBaseRule_ReturnsOkResultWithCreatedBaseRule()
    {
        // Arrange
        BaseRuleDto baseRuleDto = new();
        BaseRule baseRule = new();
        _mockMapper.Setup(m => m.Map<BaseRule>(baseRuleDto)).Returns(baseRule);
        _mockUnitOfWork.Setup(uow => uow.BaseRules.AddAsync(baseRule)).Verifiable();
        _mockUnitOfWork.Setup(uow => uow.CommitAsync()).ReturnsAsync(true);

        // Act
        IActionResult result = await _controller.CreateBaseRule(baseRuleDto);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        BaseRule returnedBaseRule = Assert.IsType<BaseRule>(okResult.Value);
        Assert.Equal(baseRule, returnedBaseRule);
        _mockUnitOfWork.Verify();
    }

    [Fact]
    public async Task UpdateBaseRule_ReturnsOkResultWithUpdatedBaseRule()
    {
        // Arrange
        int id = 1;
        BaseRuleDto baseRuleDto = new();
        BaseRule baseRule = new();
        _mockMapper.Setup(m => m.Map<BaseRule>(baseRuleDto)).Returns(baseRule);
        _mockUnitOfWork.Setup(uow => uow.BaseRules.ExistsAsync(id)).ReturnsAsync(true);
        _mockUnitOfWork.Setup(uow => uow.BaseRules.Update(baseRule)).Verifiable();
        _mockUnitOfWork.Setup(uow => uow.CommitAsync()).ReturnsAsync(true);

        // Act
        IActionResult result = await _controller.UpdateBaseRule(id, baseRuleDto);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        BaseRule returnedBaseRule = Assert.IsType<BaseRule>(okResult.Value);
        Assert.Equal(baseRule, returnedBaseRule);
        _mockUnitOfWork.Verify();
    }

    [Fact]
    public async Task DeleteBaseRule_ReturnsOkResultWithDeletedBaseRule()
    {
        // Arrange
        int id = 1;
        _mockUnitOfWork.Setup(uow => uow.BaseRules.ExistsAsync(id)).ReturnsAsync(true);
        _mockUnitOfWork.Setup(uow => uow.BaseRules.Remove(It.IsAny<BaseRule>())).Verifiable();
        _mockUnitOfWork.Setup(uow => uow.CommitAsync()).ReturnsAsync(true);

        // Act
        IActionResult result = await _controller.DeleteBaseRule(id);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        string message = Assert.IsType<string>(okResult.Value);
        Assert.Contains(id.ToString(), message);
        _mockUnitOfWork.Verify();
    }

    [Fact]
    public async Task GetTBaseRuleesByFilter_ReturnsOkResultWithCorrectBaseRules()
    {
        // Arrange
        BaseRulePaginationFilter request = new();
        List<BaseRule> baseRules = [new BaseRule()];
        List<BaseRuleDto> baseRuleDtos = _mockMapper.Object.Map<List<BaseRuleDto>>(baseRules);
        _mockUnitOfWork.Setup(uow => uow.BaseRules.GetBaseRulesByFilterAsync(request)).ReturnsAsync(baseRules);

        // Act
        IActionResult result = await _controller.GetTBaseRuleesByFilter(request);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        PaginatedList<BaseRuleDto> returnedBaseRules = Assert.IsType<PaginatedList<BaseRuleDto>>(okResult.Value);
        Assert.True(returnedBaseRules.Data.SequenceEqual(baseRuleDtos));
    }
}
