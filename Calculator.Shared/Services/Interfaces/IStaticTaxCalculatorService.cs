using Calculator.Shared.Enums;

namespace Calculator.Shared.Services.Interfaces;
public interface IStaticTaxCalculatorService
{
    bool IsItTollFreeDay(DateTime date);
    bool IsTollFreeVehicle(VehicleType vehicle);
    int CalculateTollFeeBasedOnTimeForGothenburg(DateTime date);
    int GetTollFee(DateTime date, VehicleType vehicle);
}

