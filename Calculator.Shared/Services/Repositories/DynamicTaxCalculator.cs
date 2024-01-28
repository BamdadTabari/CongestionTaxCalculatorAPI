using Calculator.Shared.EntityFramework.Configs;
using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Enums;
using Calculator.Shared.Infrastructure.Pagination;
using Calculator.Shared.Services.BaseAndConfigs;
using Calculator.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Shared.Services.Repositories;
public class DynamicTaxCalculator : Repository<CalculatedTax>, IDynamicTaxCalculatorService
{
    private readonly IQueryable<CalculatedTax> _queryable;

    public DynamicTaxCalculator(AppDbContext context) : base(context)
    {
        _queryable = DbContext.Set<CalculatedTax>();
    }

    public Task<int> CalculateTotalFeeForDateTimesAsync(VehicleType vehicle, DateTime[] dates, DateTime intervalStart)
    {
        throw new NotImplementedException();
    }

    public Task<CalculatedTax> GetCalculatedTaxByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CalculatedTax>> GetCalculatedTaxesAsync()
    {
        return await _queryable.ToListAsync();
    }

    public Task<List<CalculatedTax>> GetCalculatedTaxesByFilterAsync(DefaultPaginationFilter filter)
    {
        throw new NotImplementedException();
    }

    public async Task<CalculatedTax> GetCalculatedTaxForDateAsync(DateTime date)
    {
        return await _queryable
           .SingleOrDefaultAsync(tr => tr.Date == date) ??
           throw new NullReferenceException($"there is not any tax for this date: {date}");
    }

    public Task<int> GetTollFeeForDateTimeAsync(DateTime date, VehicleType vehicle)
    {
        throw new NotImplementedException();
    }

    public bool IsItTollFreeDay(DateTime date)
    {
        throw new NotImplementedException();
    }

    public bool IsTollFreeVehicle(VehicleType vehicle)
    {
        throw new NotImplementedException();
    }
}
