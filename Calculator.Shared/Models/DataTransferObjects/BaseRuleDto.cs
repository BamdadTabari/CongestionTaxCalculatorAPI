using Calculator.Shared.Enums;
using FluentValidation;

namespace Calculator.Shared.Models.DataTransferObjects;
public class BaseRuleDto: BaseDataTransferObject
{
    public VehicleType? Vehicle { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
    public DateTime? HolydayDateTime { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public bool HaveNotTax { get; set; }
}
public class BaseRuleDtoValidator : AbstractValidator<BaseRuleDto>
{
    public BaseRuleDtoValidator()
    {
        RuleFor(f => f.Country).NotEmpty().NotNull();
        RuleFor(f => f.City).NotEmpty().NotNull();
        RuleFor(f => f.HaveNotTax).NotEmpty().NotNull();
    }
}