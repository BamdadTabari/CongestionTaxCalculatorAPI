using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Enums;
using Calculator.Shared.Infrastructure.Pagination;

namespace Calculator.Shared.Services.Interfaces;
public interface IDynamicTaxCalculatorService : IRepository<CalculatedTax>
{
    #region async methods
    Task<CalculatedTax> GetCalculatedTaxByIdAsync(int id);
    Task<List<CalculatedTax>> GetCalculatedTaxesByFilterAsync(DefaultPaginationFilter filter);
    Task<List<CalculatedTax>> GetCalculatedTaxesAsync();
    Task<CalculatedTax> GetCalculatedTaxForDateAsync(DateTime date);
    Task<int> CalculateTotalFeeForDateTimesAsync(VehicleType vehicle, DateTime[] dates, DateTime intervalStart);
    Task<int> GetTollFeeForDateTimeAsync(DateTime date, VehicleType vehicle);

    #endregion

    #region sync methods
    bool IsTollFreeVehicle(VehicleType vehicle);
    bool IsItTollFreeDay(DateTime date);
    #endregion
}
