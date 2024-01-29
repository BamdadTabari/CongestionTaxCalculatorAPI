using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Infrastructure.Pagination;
using Calculator.Shared.Services.BaseAndConfigs;

namespace Calculator.Shared.Services.Interfaces;
public interface IBaseRuleService : IRepository<BaseRule>
{
    Task<BaseRule> GetBaseRuleByIdAsync(int id);
    Task<List<BaseRule>> GetBaseRulesWithTaxesByIdsAsync(IEnumerable<int> ids);
    Task<List<BaseRule>> GetBaseRulesByFilterAsync(BaseRulePaginationFilter filter);
    Task<List<BaseRule>> GetBaseRulesAsync();
    Task<List<BaseRule>> GetBaseRulesByContryAndCityAsync(string contry, string city);
}
