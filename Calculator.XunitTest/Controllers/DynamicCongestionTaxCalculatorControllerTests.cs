using AutoMapper;
using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Infrastructure.Pagination;
using Calculator.Shared.Models.DataTransferObjects;
using Calculator.Shared.Models.RequestModels;
using Calculator.Shared.Services.BaseAndConfigs;
using CongestionTaxCalculator.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Calculator.XunitTest.Controllers;
public class DynamicCongestionTaxCalculatorControllerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMapper> _mockMapper;
    private readonly DynamicCongestionTaxCalculatorController _controller;

    public DynamicCongestionTaxCalculatorControllerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _controller = new DynamicCongestionTaxCalculatorController(_mockUnitOfWork.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetCalculatedTaxByRequestAsync_ReturnsOkResultWithCorrectCalculatedTax()
    {
        // Arrange
        CalculateByTaxRulesIdsAndDateRequest request = new();
        CalculatedTax calculatedTax = new();
        _mockUnitOfWork.Setup(uow => uow.BaseRules.GetBaseRulesWithTaxesByIdsAsync(request.BaseRuleIds)).ReturnsAsync([]);
        _mockUnitOfWork.Setup(uow => uow.TaxRules.GetTaxRulesByFilterAsync(It.IsAny<DefaultPaginationFilter>())).ReturnsAsync([]);
        _mockUnitOfWork.Setup(uow => uow.DynamicTaxCalculator.Add(calculatedTax)).Verifiable();
        _mockUnitOfWork.Setup(uow => uow.CommitAsync()).ReturnsAsync(true);

        // Act
        IActionResult result = await _controller.GetCalculatedTaxByRequestAsync(request);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        CalculatedTax returnedCalculatedTax = Assert.IsType<CalculatedTax>(okResult.Value);
        Assert.Equal(calculatedTax, returnedCalculatedTax);
        _mockUnitOfWork.Verify();
    }

    [Fact]
    public async Task GetCalculatedTaxByRequestForTheRangeOfDateAsync_ReturnsOkResultWithCorrectCalculatedTaxes()
    {
        // Arrange
        CalculateByTaxRulesIdsAndDateRangeRequest request = new();
        List<CalculatedTax> calculatedTaxes = [new CalculatedTax()];
        _mockUnitOfWork.Setup(uow => uow.BaseRules.GetBaseRulesWithTaxesByIdsAsync(request.BaseRuleIds)).ReturnsAsync(new List<BaseRule>());
        _mockUnitOfWork.Setup(uow => uow.TaxRules.GetTaxRulesByFilterAsync(It.IsAny<DefaultPaginationFilter>())).ReturnsAsync(new List<TaxRule>());
        _mockUnitOfWork.Setup(uow => uow.DynamicTaxCalculator.AddRange(calculatedTaxes)).Verifiable();
        _mockUnitOfWork.Setup(uow => uow.CommitAsync()).ReturnsAsync(true);

        // Act
        IActionResult result = await _controller.GetCalculatedTaxByRequestForTheRangeOfDateAsync(request);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        List<CalculatedTax> returnedCalculatedTaxes = Assert.IsType<List<CalculatedTax>>(okResult.Value);
        Assert.Equal(calculatedTaxes, returnedCalculatedTaxes);
        _mockUnitOfWork.Verify();
    }

    [Fact]
    public async Task GetCalculatedTaxByIdAsync_ReturnsOkResultWithCorrectCalculatedTax()
    {
        int id = 1;
        CalculatedTax calculatedTax = new();
        _mockUnitOfWork.Setup(uow => uow.DynamicTaxCalculator.GetCalculatedTaxByIdAsync(id)).ReturnsAsync(calculatedTax);

        // Act
        IActionResult result = await _controller.GetCalculatedTaxByIdAsync(id);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        BaseRuleDto returnedBaseRule = Assert.IsType<BaseRuleDto>(okResult.Value);
        Assert.Equal(calculatedTax.Id, returnedBaseRule.Id);
    }

    [Fact]
    public async Task GetCalculatedTaxsAsync_ReturnsOkResultWithCorrectCalculatedTaxes()
    {

        List<CalculatedTax> calculatedTaxes = new() { new CalculatedTax() };
        List<CalculatedTaxDto> calculatedTaxDtos = _mockMapper.Object.Map<List<CalculatedTaxDto>>(calculatedTaxes);
        _mockUnitOfWork.Setup(uow => uow.DynamicTaxCalculator.GetCalculatedTaxesAsync()).ReturnsAsync(calculatedTaxes);

        // Act
        IActionResult result = await _controller.GetCalculatedTaxsAsync();

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        List<CalculatedTaxDto> returnedCalculatedTaxes = Assert.IsType<List<CalculatedTaxDto>>(okResult.Value);
        Assert.True(returnedCalculatedTaxes.SequenceEqual(calculatedTaxDtos));
    }

    [Fact]
    public async Task CreateCalculatedTax_ReturnsOkResultWithCreatedCalculatedTax()
    {
        // Arrange
        CalculatedTaxDto calculatedTaxDto = new();
        CalculatedTax calculatedTax = new();
        _mockMapper.Setup(m => m.Map<CalculatedTax>(calculatedTaxDto)).Returns(calculatedTax);
        _mockUnitOfWork.Setup(uow => uow.DynamicTaxCalculator.Add(calculatedTax)).Verifiable();
        _mockUnitOfWork.Setup(uow => uow.CommitAsync()).ReturnsAsync(true);

        // Act
        IActionResult result = await _controller.CreateCalculatedTax(calculatedTaxDto);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        CalculatedTax returnedCalculatedTax = Assert.IsType<CalculatedTax>(okResult.Value);
        Assert.Equal(calculatedTax, returnedCalculatedTax);
        _mockUnitOfWork.Verify();
    }
}