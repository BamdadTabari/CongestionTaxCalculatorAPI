using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Infrastructure.Pagination;
using Calculator.Shared.Services.BaseAndConfigs;

namespace Calculator.Shared.Services.Interfaces;
public interface ITaxRulesService : IRepository<TaxRule>
{
    #region async methods
    Task<TaxRule> GetTaxRuleByIdAsync(int id);
    Task<List<TaxRule>> GetTaxRulesByFilterAsync(DefaultPaginationFilter filter);
    Task<List<TaxRule>> GetTaxRulesAsync();
    Task<TaxRule> GetTaxRuleForTimeAsync(TimeOnly time);
    #endregion
}