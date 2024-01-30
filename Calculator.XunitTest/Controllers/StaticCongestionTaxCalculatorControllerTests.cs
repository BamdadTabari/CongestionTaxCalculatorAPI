using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Enums;
using Calculator.Shared.Models.RequestModels;
using Calculator.Shared.Services.BaseAndConfigs;
using CongestionTaxCalculator.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Calculator.XunitTest.Controllers;
public class StaticCongestionTaxCalculatorControllerTests
{
    protected readonly Mock<IUnitOfWork> _mockUnitOfWork;
    protected readonly StaticCongestionTaxCalculatorController _controller;

    public StaticCongestionTaxCalculatorControllerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _controller = new StaticCongestionTaxCalculatorController(_mockUnitOfWork.Object);
    }

    [Fact]
    public async Task GetCalculatedTaxForSpesificDatesTest_ReturnsOkResultWithCorrectTax()
    {
        // Arrange
        CalculateByDatesAndVehicleRequest request = new(VehicleType.Car, [DateTime.Now]);
        decimal expectedTax = 50m;
        _mockUnitOfWork.Setup(uow => uow.DynamicTaxCalculator.CalculateTotalFeeForDateTimesAsync(It.IsAny<VehicleType>(), It.IsAny<DateTime[]>(), It.IsAny<DateTime>()))
            .ReturnsAsync(expectedTax);

        // Act
        IActionResult result = await _controller.GetCalculatedTaxForSpesificDates(request);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        decimal returnedTax = Assert.IsType<decimal>(okResult.Value);
        Assert.Equal(expectedTax, returnedTax);
    }

    [Fact]
    public async Task GetGothenburgCalculatedTaxForSpesificDateTest_ReturnsOkResultWithCorrectTax()
    {
        // Arrange
        CalculateByDateAndVehicleRequest request = new(VehicleType.Car, DateTime.Now);
        decimal expectedTax = 50m;
        _mockUnitOfWork.Setup(uow => uow.DynamicTaxCalculator.GetTollFeeForDateTimeAsync(It.IsAny<DateTime>(), It.IsAny<VehicleType>()))
            .ReturnsAsync(expectedTax);

        // Act
        IActionResult result = await _controller.GetGothenburgCalculatedTaxForSpesificDate(request);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        CalculatedTax returnedTax = Assert.IsType<CalculatedTax>(okResult.Value);
        Assert.Equal(expectedTax, returnedTax.AmountOfDay);
    }

    [Fact]
    public void GetTaxForGothenburgTest_ReturnsOkResultWithCorrectTax()
    {
        // Arrange
        VehicleType vehicle = VehicleType.Car;
        DateTime[] dates = [DateTime.Now];
        int expectedTax = 50;
        _mockUnitOfWork.Setup(uow => uow.StaticTaxCalculator.GetTollFee(It.IsAny<DateTime>(), It.IsAny<VehicleType>()))
            .Returns(expectedTax);

        // Act
        IActionResult result = _controller.GetTaxForGothenburg(vehicle, dates);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
        int returnedTax = Assert.IsType<int>(okResult.Value);
        Assert.Equal(expectedTax, returnedTax);
    }
}
