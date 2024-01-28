using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Enums;
using Calculator.Shared.Infrastructure.Pagination;
using Calculator.Shared.Services.BaseAndConfigs;

namespace Calculator.Shared.Services.Interfaces;
public interface IDynamicTaxCalculatorService : IRepository<CalculatedTax>
{
    #region async methods
    Task<CalculatedTax> GetCalculatedTaxByIdAsync(int id);
    Task<List<CalculatedTax>> GetCalculatedTaxesByFilterAsync(DefaultPaginationFilter filter);
    Task<List<CalculatedTax>> GetCalculatedTaxesAsync();
    Task<CalculatedTax> GetCalculatedTaxForDateTimeAsync(DateTime date);
    Task<decimal> CalculateTotalFeeForDateTimesAsync(VehicleType vehicle, DateTime[] dates, DateTime intervalStart);
    Task<decimal> GetTollFeeForDateTimeAsync(DateTime date, VehicleType vehicle);

    #endregion

    #region sync methods
    bool IsTollFreeVehicle(VehicleType vehicle);
    bool IsItTollFreeDay(DateTime date);
    #endregion
}
