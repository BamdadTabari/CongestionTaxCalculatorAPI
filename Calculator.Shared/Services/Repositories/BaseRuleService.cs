using Calculator.Shared.EntityFramework.Configs;
using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.EntityFramework.Extensions;
using Calculator.Shared.Infrastructure.Pagination;
using Calculator.Shared.Services.BaseAndConfigs;
using Calculator.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Shared.Services.Repositories;
public class BaseRuleService : Repository<BaseRule>, IBaseRuleService
{
    private readonly IQueryable<BaseRule> _queryable;

    public BaseRuleService(AppDbContext context) : base(context)
    {
        _queryable = DbContext.Set<BaseRule>();
    }

    public async Task<BaseRule> GetBaseRuleByIdAsync(int id)
    {
        return await _queryable
        .SingleOrDefaultAsync(x => x.Id == id) ??
            throw new NullReferenceException($"there is not any Base Rule for this Id: {id}");
    }

    public async Task<List<BaseRule>> GetBaseRulesAsync()
    {
        return await _queryable.AsNoTracking().ToListAsync();
    }

    public async Task<List<BaseRule>> GetBaseRulesByFilterAsync(BaseRulePaginationFilter filter)
    {
        return await _queryable.AsNoTracking()
           .ApplyFilter(filter)
           .ApplySort(filter.SortByEnum)
           .Paginate(filter.Page, filter.PageSize)
           .ToListAsync();
    }
}
