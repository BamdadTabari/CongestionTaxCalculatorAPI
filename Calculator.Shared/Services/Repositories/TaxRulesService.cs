using Calculator.Shared.EntityFramework.Configs;
using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.EntityFramework.Extensions;
using Calculator.Shared.Infrastructure.Pagination;
using Calculator.Shared.Services.BaseAndConfigs;
using Calculator.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Shared.Services.Repositories;
public class TaxRulesService : Repository<TaxRule>, ITaxRulesService
{
    private readonly IQueryable<TaxRule> _queryable;

    public TaxRulesService(AppDbContext context) : base(context)
    {
        _queryable = DbContext.Set<TaxRule>();
    }

    public async Task<List<TaxRule>> GetTaxRulesAsync()
    {
        return await _queryable.AsNoTracking().ToListAsync();
    }

    public async Task<TaxRule> GetTaxRuleForTimeAsync(TimeOnly time)
    {
        return await _queryable
            .SingleOrDefaultAsync(tr => tr.StartTime <= time && tr.EndTime >= time) ??
            throw new NullReferenceException($"there is not any tax rule for this date: {time}");
    }

    public async Task<TaxRule> GetTaxRuleByIdAsync(int id)
    {
        return await _queryable
        .SingleOrDefaultAsync(x => x.Id == id) ??
            throw new NullReferenceException($"there is not any tax rule for this Id: {id}");
    }

    public async Task<List<TaxRule>> GetTaxRulesByIdsAsync(IEnumerable<int> ids)
    {
        // Filter by ids
        if (ids?.Any() == true)
            return await _queryable.Where(x => ids.Contains(x.Id)).ToListAsync();

        return [];
    }

    public async Task<List<TaxRule>> GetTaxRulesByFilterAsync(DefaultPaginationFilter filter)
    {
        return await _queryable.AsNoTracking()
            .ApplyFilter(filter)
            .ApplySort(filter.SortByEnum)
            .Paginate(filter.Page, filter.PageSize)
            .ToListAsync();
    }
}

