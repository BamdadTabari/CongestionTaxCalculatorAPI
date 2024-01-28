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
        return await _queryable.ToListAsync();
    }

    public async Task<TaxRule> GetTaxRuleForTimeAsync(TimeOnly time)
    {
        return await _queryable
            .SingleOrDefaultAsync(tr => tr.StartTime <= time && tr.EndTime >= time) ??
            throw new NullReferenceException($"there is not any tax for this date: {time}");
    }

    public async Task<TaxRule> GetTaxRuleByIdAsync(int id)
    {
        return await _queryable
        .SingleOrDefaultAsync(x => x.Id == id) ??
            throw new NullReferenceException($"there is not any tax for this Id: {id}");
    }

    public async Task<List<TaxRule>> GetTaxRulesByFilterAsync(DefaultPaginationFilter filter)
    {

        return await _queryable.AsNoTracking()
            .ApplyFilter(filter)
            .ApplySort(filter.SortByEnum)
            .Paginate(filter.Page, filter.PageSize)
            .ToListAsync();
    }

    //public bool IsItTollFreeDay(DateTime date)
    //{
    //    int year = date.Year;
    //    int month = date.Month;
    //    int day = date.Day;

    //    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

    //    if (year == 2013)
    //    {
    //        if (month == 1 && day == 1 ||
    //            month == 3 && (day == 28 || day == 29) ||
    //            month == 4 && (day == 1 || day == 30) ||
    //            month == 5 && (day == 1 || day == 8 || day == 9) ||
    //            month == 6 && (day == 5 || day == 6 || day == 21) ||
    //            month == 7 ||
    //            month == 11 && day == 1 ||
    //            month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    //public bool IsTollFreeVehicle(VehicleType vehicleType)
    //{
    //    bool isFree = vehicleType == VehicleType.Motorbike || vehicleType == VehicleType.Bus ||
    //           vehicleType == VehicleType.Diplomat || vehicleType == VehicleType.Military ||
    //           vehicleType == VehicleType.Foreign || vehicleType == VehicleType.Emergency;
    //    if (isFree)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    //public async Task<int> CalculateTotalFeeAsync(VehicleType vehicle, DateTime[] dates, DateTime intervalStart)
    //{
    //    int totalFee = 0;
    //    int maxFeeWithin60Minutes = 0;
    //    foreach (DateTime date in dates)
    //    {
    //        if (!IsTollFreeVehicle(vehicle))
    //        {
    //            int tollFee = await GetTollFeeAsync(date, vehicle);
    //            totalFee += tollFee;
    //            if (tollFee > maxFeeWithin60Minutes)
    //                maxFeeWithin60Minutes = tollFee;

    //            // Check if the difference between the current date and the start of the interval is more than 60 minutes
    //            if ((date - intervalStart).TotalMinutes > 60)
    //            {
    //                // Reset the start of the interval to the current date
    //                intervalStart = date;
    //                // Reset the maximum fee within the 60-minute interval
    //                maxFeeWithin60Minutes = 0;
    //            }
    //        }
    //    }
    //    return Math.Max(totalFee, maxFeeWithin60Minutes);
    //}

    //public async Task<int> GetTollFeeAsync(DateTime date, VehicleType vehicle)
    //{
    //    if (IsItTollFreeDay(date) || IsTollFreeVehicle(vehicle)) return 0;

    //    // Fetch the tax rule for the current date
    //    TaxRule taxRule = await GetTaxRuleForTimeAsync(date) ??
    //        throw new Exception($"No tax rule found for date {date}");

    //    // Return the tax amount from the tax rule
    //    return (int)taxRule.TaxAmount;
    //}
}

