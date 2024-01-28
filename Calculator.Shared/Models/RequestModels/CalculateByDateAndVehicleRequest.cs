using Calculator.Shared.Enums;

namespace Calculator.Shared.Models.RequestModels;
public record CalculateByDateAndVehicleRequest(VehicleType Vehicle, DateTime Date);