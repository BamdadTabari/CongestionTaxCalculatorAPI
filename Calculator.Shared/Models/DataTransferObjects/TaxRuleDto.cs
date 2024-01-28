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
