using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Infrastructure.Pagination;

namespace Calculator.Shared.Services.Interfaces;
public interface IDynamicTaxRulesService : IRepository<TaxRule>
{

    #region async methods
    Task<TaxRule> GetTaxRuleByIdAsync(int id);
    Task<List<TaxRule>> GetTaxRulesByFilterAsync(DefaultPaginationFilter filter);
    Task<List<TaxRule>> GetTaxRulesAsync();
    Task<TaxRule> GetTaxRuleForTimeAsync(TimeOnly time);
    //Task<int> CalculateTotalFeeAsync(VehicleType vehicle, DateTime[] dates, DateTime intervalStart);
    //Task<int> GetTollFeeAsync(DateTime date, VehicleType vehicle);

    #endregion

    //#region sync methods
    //bool IsTollFreeVehicle(VehicleType vehicle);
    //bool IsItTollFreeDay(DateTime date);
    //#endregion
}