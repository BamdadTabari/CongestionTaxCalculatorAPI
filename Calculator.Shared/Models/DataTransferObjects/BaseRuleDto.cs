using Calculator.Shared.Enums;

namespace Calculator.Shared.Models.DataTransferObjects;
public class BaseRuleDto
{
    public VehicleType? Vehicle { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
    public DateTime? HolydayDateTime { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public bool HaveNotTax { get; set; }
}
