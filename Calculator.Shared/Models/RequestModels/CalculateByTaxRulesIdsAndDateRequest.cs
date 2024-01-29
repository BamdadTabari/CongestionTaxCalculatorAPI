using Calculator.Shared.Models.DataTransferObjects;
using FluentValidation;

namespace Calculator.Shared.Models.RequestModels;
public record CalculateByTaxRulesIdsAndDateRequest(List<int> BaseRuleIds,
                                                    DateTime Date,
                                                    List<TimesAndCountofVehiclesAtThoseTime> TimesAndCountOfVehicles);
public record TimesAndCountofVehiclesAtThoseTime(int CountOfVehicles, TimeOnly FromTime, TimeOnly ToTime);

public class CalculateByTaxRulesIdsAndDateRequestValidator : AbstractValidator<CalculateByTaxRulesIdsAndDateRequest>
{
    public CalculateByTaxRulesIdsAndDateRequestValidator()
    {
        RuleFor(f => f.BaseRuleIds).NotEmpty().NotNull();
        RuleFor(f => f.Date).NotEmpty().NotNull();
        RuleFor(f => f.TimesAndCountOfVehicles).NotEmpty().NotNull();
    }
}
public class TimesAndCountofVehiclesAtThoseTimeValidator : AbstractValidator<TimesAndCountofVehiclesAtThoseTime>
{
    public TimesAndCountofVehiclesAtThoseTimeValidator()
    {
        RuleFor(f => f.CountOfVehicles).NotEmpty().NotNull();
        RuleFor(f => f.FromTime).NotEmpty().NotNull().LessThan(f => f.ToTime);
        RuleFor(f => f.ToTime).NotEmpty().NotNull();
    }
}