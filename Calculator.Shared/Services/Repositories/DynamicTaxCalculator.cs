using Calculator.Shared.EntityFramework.Configs;
using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.EntityFramework.Extensions;
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


    public async Task<CalculatedTax> GetCalculatedTaxByIdAsync(int id)
    {
        return await _queryable
        .SingleOrDefaultAsync(x => x.Id == id) ??
            throw new NullReferenceException($"there is not any calculated tax for this Id: {id}");
    }

    public async Task<List<CalculatedTax>> GetCalculatedTaxesAsync()
    {
        return await _queryable.ToListAsync();
    }

    public async Task<List<CalculatedTax>> GetCalculatedTaxesByFilterAsync(DefaultPaginationFilter filter)
    {
        return await _queryable.AsNoTracking()
           .ApplyFilter(filter)
           .ApplySort(filter.SortByEnum)
           .Paginate(filter.Page, filter.PageSize)
           .ToListAsync();
    }

    public async Task<CalculatedTax> GetCalculatedTaxForDateTimeAsync(DateTime date)
    {
        return await _queryable
           .SingleOrDefaultAsync(tr => tr.Date == date) ??
           throw new NullReferenceException($"there is not any calculated tax for this date: {date}");
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
        bool isFree = vehicleType == VehicleType.Motorbike || vehicleType == VehicleType.Bus ||
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

    public async Task<decimal> CalculateTotalFeeForDateTimesAsync(VehicleType vehicle, DateTime[] dates, DateTime intervalStart)
    {
        decimal totalFee = 0;
        decimal maxFeeWithin60Minutes = 0;
        foreach (DateTime date in dates)
        {
            if (!IsTollFreeVehicle(vehicle))
            {
                decimal tollFee = await GetTollFeeForDateTimeAsync(date, vehicle);
                totalFee += tollFee;
                if (tollFee > maxFeeWithin60Minutes)
                    maxFeeWithin60Minutes = tollFee;

                // Check if the difference between the current date and the start of the interval is more than 60 minutes
                if ((date - intervalStart).TotalMinutes > 60)
                {
                    // Reset the start of the interval to the current date
                    intervalStart = date;
                    // Reset the maximum fee within the 60-minute interval
                    maxFeeWithin60Minutes = 0;
                }
            }
        }
        return Math.Max(totalFee, maxFeeWithin60Minutes);
    }


    public async Task<decimal> GetTollFeeForDateTimeAsync(DateTime date, VehicleType vehicle)
    {
        if (IsItTollFreeDay(date) || IsTollFreeVehicle(vehicle)) return 0;

        // Fetch the tax rule for the current date
        CalculatedTax calculatedTax = await _queryable.SingleOrDefaultAsync(x=>x.Date == date) ??
            throw new Exception($"No calculated tax  found for date {date}");

        // Return the  amount from the calculated tax 
        return calculatedTax.AmountOfDay;
    }
}
