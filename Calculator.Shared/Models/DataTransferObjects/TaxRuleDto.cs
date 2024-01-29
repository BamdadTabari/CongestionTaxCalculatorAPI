using FluentValidation;

namespace Calculator.Shared.Models.DataTransferObjects;
public class TaxRuleDto : BaseDataTransferObject
{
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string MonetaryUnit { get; set; }
    public decimal TaxAmount { get; set; }
}
public class TaxRuleDtoValidator : AbstractValidator<TaxRuleDto>
{
    public TaxRuleDtoValidator()
    {
        RuleFor(f => f.Country).NotEmpty().NotNull();
        RuleFor(f => f.MonetaryUnit).NotEmpty().NotNull();
        RuleFor(f => f.StartTime).NotEmpty().NotNull();
        RuleFor(f => f.EndTime).NotEmpty().NotNull();
        RuleFor(f => f.City).NotEmpty().NotNull();
    }
}