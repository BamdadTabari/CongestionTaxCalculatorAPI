namespace Calculator.Shared.Models.DataTransferObjects;
public class TaxRuleDto : BaseDataTransferObject
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string MonetaryUnit { get; set; }
    public decimal TaxAmount { get; set; }
}
