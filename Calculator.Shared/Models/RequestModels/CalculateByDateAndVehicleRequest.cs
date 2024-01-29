using Calculator.Shared.Enums;
using Calculator.Shared.Models.DataTransferObjects;
using FluentValidation;

namespace Calculator.Shared.Models.RequestModels;
public record CalculateByDateAndVehicleRequest(VehicleType Vehicle, DateTime Date);

public class CalculateByDateAndVehicleRequestValidator : AbstractValidator<CalculateByDateAndVehicleRequest>
{
    public CalculateByDateAndVehicleRequestValidator()
    {
        RuleFor(f => f.Vehicle).NotEmpty().NotNull();
        RuleFor(f => f.Date).NotEmpty().NotNull();
    }
}