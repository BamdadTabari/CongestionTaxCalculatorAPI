using Calculator.Shared.Enums;
using FluentValidation;

namespace Calculator.Shared.Models.RequestModels;
public record CalculateByDatesAndVehicleRequest(VehicleType Vehicle, DateTime[] Dates);


public class CalculateByDatesAndVehicleRequestValidator : AbstractValidator<CalculateByDatesAndVehicleRequest>
{
    public CalculateByDatesAndVehicleRequestValidator()
    {
        RuleFor(f => f.Vehicle).NotEmpty().NotNull();
        RuleFor(f => f.Dates).NotEmpty().NotNull();
    }
}
