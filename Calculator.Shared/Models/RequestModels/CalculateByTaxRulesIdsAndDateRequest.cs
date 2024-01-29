using FluentValidation;

namespace Calculator.Shared.Models.RequestModels;
public class CalculateByTaxRulesIdsAndDateRequest()
{
    public List<int>? BaseRuleIds { get; set; }
    public DateTime Date { get; set; }
    public List<TimesAndCountofVehiclesAtThoseTime>? TimesAndCountOfVehicles { get; set; }
}
public class TimesAndCountofVehiclesAtThoseTime()
{
    public int CountOfVehicles { get; set; }
    public TimeOnly FromTime { get; set; }
    public TimeOnly ToTime { get; set; }
}

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