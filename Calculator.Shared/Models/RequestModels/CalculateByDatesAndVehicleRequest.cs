using Calculator.Shared.Enums;

namespace Calculator.Shared.Models.RequestModels;
public record CalculateByDatesAndVehicleRequest(VehicleType Vehicle, DateTime[] Dates);
