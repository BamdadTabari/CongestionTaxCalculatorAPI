using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Enums;
using Calculator.Shared.Models.RequestModels;
using Calculator.Shared.Services.BaseAndConfigs;
using CongestionTaxCalculator.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        var request = new CalculateByDatesAndVehicleRequest(VehicleType.Car, [ DateTime.Now ]);
        var expectedTax = 50m;
        _mockUnitOfWork.Setup(uow => uow.DynamicTaxCalculator.CalculateTotalFeeForDateTimesAsync(It.IsAny<VehicleType>(), It.IsAny<DateTime[]>(), It.IsAny<DateTime>()))
            .ReturnsAsync(expectedTax);

        // Act
        var result = await _controller.GetCalculatedTaxForSpesificDates(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedTax = Assert.IsType<decimal>(okResult.Value);
        Assert.Equal(expectedTax, returnedTax);
    }

    [Fact]
    public async Task GetGothenburgCalculatedTaxForSpesificDateTest_ReturnsOkResultWithCorrectTax()
    {
        // Arrange
        var request = new CalculateByDateAndVehicleRequest(VehicleType.Car, DateTime.Now);
        var expectedTax = 50m;
        _mockUnitOfWork.Setup(uow => uow.DynamicTaxCalculator.GetTollFeeForDateTimeAsync(It.IsAny<DateTime>(), It.IsAny<VehicleType>()))
            .ReturnsAsync(expectedTax);

        // Act
        var result = await _controller.GetGothenburgCalculatedTaxForSpesificDate(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedTax = Assert.IsType<CalculatedTax>(okResult.Value);
        Assert.Equal(expectedTax, returnedTax.AmountOfDay);
    }

    [Fact]
    public void GetTaxForGothenburgTest_ReturnsOkResultWithCorrectTax()
    {
        // Arrange
        var vehicle = VehicleType.Car;
        var dates = new[] { DateTime.Now };
        var expectedTax = 50;
        _mockUnitOfWork.Setup(uow => uow.StaticTaxCalculator.GetTollFee(It.IsAny<DateTime>(), It.IsAny<VehicleType>()))
            .Returns(expectedTax);

        // Act
        var result = _controller.GetTaxForGothenburg(vehicle, dates);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedTax = Assert.IsType<int>(okResult.Value);
        Assert.Equal(expectedTax, returnedTax);
    }
}
