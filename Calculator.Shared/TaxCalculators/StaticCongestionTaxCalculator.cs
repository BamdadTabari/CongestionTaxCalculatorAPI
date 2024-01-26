using Calculator.Shared.Enums;
using Calculator.Shared.Services.Interfaces;

namespace Calculator.Shared.TaxCalculators
{
    // this is based on our static data and not related to the database at all 
    // it is just design for Gothenburg with 2013 data
    public class StaticCongestionTaxCalculator(IStaticTaxRulesService taxRulesService)
    {
        private readonly IStaticTaxRulesService _taxRulesService = taxRulesService;

        public int GetTaxForGothenburg(VehicleType vehicle, DateTime[] dates)
        {
            DateTime intervalStart = dates[0];
            int totalFee = 0;
            foreach (DateTime date in dates)
            {
                int nextFee = GetTollFee(date, vehicle);
                int tempFee = GetTollFee(intervalStart, vehicle);

                long diffInMillies = date.Millisecond - intervalStart.Millisecond;
                long minutes = diffInMillies / 1000 / 60;

                if (minutes <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee += nextFee;
                }
            }
            if (totalFee > 60) totalFee = 60;
            return totalFee;
        }

        public int GetTollFee(DateTime date, VehicleType vehicle)
        {
            if (_taxRulesService.IsItTollFreeDay(date) || _taxRulesService.IsTollFreeVehicle(vehicle)) return 0;

            return _taxRulesService.CalculateTollFeeBasedOnTimeForGothenburg(date);
        }

    }
}
