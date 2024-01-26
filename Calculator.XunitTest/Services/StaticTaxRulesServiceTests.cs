using Calculator.Shared.Enums;
using Calculator.Shared.Services.Interfaces;
using Calculator.Shared.Services.Repositories;

namespace Calculator.XunitTest.Services;
public class StaticTaxRulesServiceTests
{
    private readonly IStaticTaxRulesService _service;

    public StaticTaxRulesServiceTests()
    {
        _service = new StaticTaxRulesService();
    }

    [Fact]
    public void CalculateTollFeeBasedOnTimeForGothenburg_ReturnsCorrectFee()
    {
        // Arrange
        DateTime date = new(2000, 1, 1, 6, 30, 0);

        // Act
        int result = _service.CalculateTollFeeBasedOnTimeForGothenburg(date);

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void GetTollFee_ReturnsFeeForVehicleAndDateTime()
    {
        // Arrange
        DateTime dateTime = new(2013, 1, 1, 6, 30, 0);
        VehicleType vehicle = VehicleType.Bus;

        // Act
        int result = _service.GetTollFee(dateTime, vehicle);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void IsItTollFreeDay_ReturnsTrueForWeekend()
    {
        // Arrange
        DateTime date = new(2000, 1, 1);

        // Act
        bool result = _service.IsItTollFreeDay(date);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsItTollFreeDay_ReturnsFalseForWeekday()
    {
        // Arrange
        DateTime date = new(2000, 1, 2);

        // Act
        bool result = _service.IsItTollFreeDay(date);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsTollFreeVehicle_ReturnsTrueForMotorbike()
    {
        // Arrange
        VehicleType vehicleType = VehicleType.Motorbike;

        // Act
        bool result = _service.IsTollFreeVehicle(vehicleType);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsTollFreeVehicle_ReturnsFalseForCar()
    {
        // Arrange
        VehicleType vehicleType = VehicleType.Car;

        // Act
        bool result = _service.IsTollFreeVehicle(vehicleType);

        // Assert
        Assert.False(result);
    }
}

