using Calculator.Shared.EntityFramework.Configs;
using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Enums;
using Calculator.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Shared.Services.Repositories;
public class DynamicTaxRulesService : Repository<TaxRule>, IDynamicTaxRulesService
{
    private readonly IQueryable<TaxRule> _queryable;

    public DynamicTaxRulesService(AppDbContext context) : base(context)
    {
        _queryable = DbContext.Set<TaxRule>();
    }

    public async Task<List<TaxRule>> GetTaxRulesAsync()
    {
        return await _queryable.ToListAsync();
    }

    public async Task<TaxRule> GetTaxRuleForDateAsync(DateTime date)
    {
        return await _queryable
            .SingleOrDefaultAsync(tr => tr.StartTime <= date && tr.EndTime >= date) ??
            throw new NullReferenceException($"there is not any tax for this date: {date}");
    }

    public bool IsItTollFreeDay(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;

        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

        if (year == 2013)
        {
            if (month == 1 && day == 1 ||
                month == 3 && (day == 28 || day == 29) ||
                month == 4 && (day == 1 || day == 30) ||
                month == 5 && (day == 1 || day == 8 || day == 9) ||
                month == 6 && (day == 5 || day == 6 || day == 21) ||
                month == 7 ||
                month == 11 && day == 1 ||
                month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
            {
                return true;
            }
        }
        return false;
    }

    public bool IsTollFreeVehicle(VehicleType vehicleType)
    {
        var isFree = vehicleType == VehicleType.Motorbike || vehicleType == VehicleType.Bus ||
               vehicleType == VehicleType.Diplomat || vehicleType == VehicleType.Military ||
               vehicleType == VehicleType.Foreign || vehicleType == VehicleType.Emergency;
        if (isFree)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

