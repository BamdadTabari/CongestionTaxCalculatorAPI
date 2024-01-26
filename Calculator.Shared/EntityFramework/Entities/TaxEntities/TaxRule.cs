namespace Calculator.Shared.EntityFramework.Entities.TaxEntities
{
    public class TaxRule : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TaxAmount { get; set; }
    }
}
