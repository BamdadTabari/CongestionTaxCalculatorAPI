using Calculator.Shared.Enums;
using Calculator.Shared.Infrastructure.Routes;
using Calculator.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Controllers;
[Route(CalculatorRotes.StaticCalculator)]
[ApiController]
public class StaticCongestionTaxCalculatorController : ControllerBase
{
    // this is based on our static data and not related to the database at all 
    // it is just design for Gothenburg with 2013 data
    public class StaticCongestionTaxCalculator(IUnitOfWork unitOfWork)
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        [Route("get-tax-for-gothenburg")]
        public int GetTaxForGothenburg(VehicleType vehicle, DateTime[] dates)
        {
            DateTime intervalStart = dates[0];
            int totalFee = 0;
            foreach (DateTime date in dates)
            {
                int nextFee = _unitOfWork.StaticTaxRules.GetTollFee(date, vehicle);
                int tempFee = _unitOfWork.StaticTaxRules.GetTollFee(intervalStart, vehicle);

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
    }
}
