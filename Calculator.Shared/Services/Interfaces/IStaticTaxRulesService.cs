using Calculator.Shared.Enums;

namespace Calculator.Shared.Services.Interfaces;
public interface IStaticTaxRulesService
{
    bool IsItTollFreeDay(DateTime date);
    bool IsTollFreeVehicle(VehicleType vehicle);
    int CalculateTollFeeBasedOnTimeForGothenburg(DateTime date);
    int GetTollFee(DateTime date, VehicleType vehicle);
}

