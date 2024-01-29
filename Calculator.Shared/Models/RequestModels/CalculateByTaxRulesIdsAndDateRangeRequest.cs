using FluentValidation;

namespace Calculator.Shared.Models.RequestModels;

public class CalculateByTaxRulesIdsAndDateRangeRequest()
{
    public List<int>? BaseRuleIds { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public List<TimesAndCountofVehiclesAtThoseTime>? TimesAndCountOfVehicles { get; set; }
}
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
