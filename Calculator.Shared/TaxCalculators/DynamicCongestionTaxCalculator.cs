using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Enums;
using Calculator.Shared.Services.Interfaces;

namespace Calculator.Shared.TaxCalculators;

public class DynamicCongestionTaxCalculator(IDynamicTaxRulesService taxRulesService)
{
    /**
         * Calculate the total toll fee for one day
         *
         * @param vehicle - the vehicle
         * @param dates   - date and time of all passes on one day
         * @return - the total congestion tax for that day
         */
    private readonly IDynamicTaxRulesService _taxRulesService = taxRulesService;

    public async Task<int> GetTaxFromDataBase(VehicleType vehicle, DateTime[] dates)
    {
        DateTime intervalStart = dates[0];
        int totalFee = await CalculateTotalFeeAsync(vehicle, dates, intervalStart);
        if (totalFee > 60) totalFee = 60;
        return totalFee;
    }

    private async Task<int> CalculateTotalFeeAsync(VehicleType vehicle, DateTime[] dates, DateTime intervalStart)
    {
        int totalFee = 0;
        int maxFeeWithin60Minutes = 0;
        foreach (DateTime date in dates)
        {
            if (!_taxRulesService.IsTollFreeVehicle(vehicle))
            {
                int tollFee = await GetTollFeeAsync(date, vehicle);
                totalFee += tollFee;
                if (tollFee > maxFeeWithin60Minutes)
                {
                    maxFeeWithin60Minutes = tollFee;
                }

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


    public async Task<int> GetTollFeeAsync(DateTime date, VehicleType vehicle)
    {
        if (_taxRulesService.IsItTollFreeDay(date) || _taxRulesService.IsTollFreeVehicle(vehicle)) return 0;

        // Fetch the tax rule for the current date
        TaxRule taxRule = await _taxRulesService.GetTaxRuleForDateAsync(date);

        // If no tax rule is found for the current date, throw an exception or return a default value
        if (taxRule == null)
        {
            throw new Exception($"No tax rule found for date {date}");
            // Or return a default value
            // return 0;
        }

        // Return the tax amount from the tax rule
        return (int)taxRule.TaxAmount;
    }

    public async Task<List<TaxRule>> GetTaxRulesAsync() => await _taxRulesService.GetTaxRulesAsync();

}
