using FluentValidation;

namespace Calculator.Shared.Models.RequestModels;

public record CalculateByTaxRulesIdsAndDateRangeRequest(List<int> BaseRuleIds,
                                                    DateTime FromDate,
                                                    DateTime ToDate,
                                                    List<TimesAndCountofVehiclesAtThoseTime> TimesAndCountOfVehicles);

public class CalculateByTaxRulesIdsAndDateRangeRequestValidator : AbstractValidator<CalculateByTaxRulesIdsAndDateRangeRequest>
{
    public CalculateByTaxRulesIdsAndDateRangeRequestValidator()
    {
        RuleFor(f => f.BaseRuleIds).NotEmpty().NotNull();
        RuleFor(f => f.FromDate).NotEmpty().NotNull();
        RuleFor(f => f.ToDate).NotEmpty().NotNull();
        RuleFor(f => f.TimesAndCountOfVehicles).NotEmpty().NotNull();
    }
}
