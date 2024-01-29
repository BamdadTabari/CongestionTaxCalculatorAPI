using FluentValidation;

namespace Calculator.Shared.Models.DataTransferObjects;
public class CalculatedTaxDto : BaseDataTransferObject
{
    public DateTime Date { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string MonetaryUnit { get; set; }
    public decimal AmountOfDay { get; set; }
}

public class CalculatedTaxDtoValidator : AbstractValidator<CalculatedTaxDto>
{
    public CalculatedTaxDtoValidator()
    {
        RuleFor(f => f.Country).NotEmpty().NotNull();
        RuleFor(f => f.MonetaryUnit).NotEmpty().NotNull();
        RuleFor(f => f.AmountOfDay).NotEmpty().NotNull();
        RuleFor(f => f.Date).NotEmpty().NotNull();
        RuleFor(f => f.City).NotEmpty().NotNull();
    }
}