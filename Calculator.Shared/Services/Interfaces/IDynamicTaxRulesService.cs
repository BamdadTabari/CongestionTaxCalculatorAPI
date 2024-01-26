using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Enums;
using Calculator.Shared.Infrastructure.Pagination;

namespace Calculator.Shared.Services.Interfaces;
public interface IDynamicTaxRulesService : IRepository<TaxRule>
{

    #region async methods
    Task<TaxRule> GetClaimByIdAsync(int id);
    Task<List<TaxRule>> GetClaimsByFilterAsync(DefaultPaginationFilter filter);
    Task<List<TaxRule>> GetTaxRulesAsync();
    Task<TaxRule> GetTaxRuleForDateAsync(DateTime date);
    #endregion

    #region syncc methods
    bool IsTollFreeVehicle(VehicleType vehicle);
    bool IsItTollFreeDay(DateTime date);
    #endregion
}