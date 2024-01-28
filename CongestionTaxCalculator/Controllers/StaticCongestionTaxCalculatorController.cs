using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Enums;
using Calculator.Shared.Infrastructure.Routes;
using Calculator.Shared.Models.RequestModels;
using Calculator.Shared.Services.BaseAndConfigs;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Controllers;

[Route(CalculatorRotes.GothenburgStaticCalculator)]
[ApiController]
public class StaticCongestionTaxCalculatorController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    #region Will Save in DataBase

    [HttpGet]
    [Route("get-calculated-tax-based-on-date-times-and-vehicle")]
    public async Task<IActionResult> GetCalculatedTaxForSpesificDates([FromBody] CalculateByDatesAndVehicleRequest request)
    {
        try
        {
            DateTime intervalStart = request.Dates[0];
            decimal totalFee = await _unitOfWork.DynamicTaxCalculator.CalculateTotalFeeForDateTimesAsync(request.Vehicle, request.Dates, intervalStart);
            if (totalFee > 60) totalFee = 60;
            return Ok(totalFee);
        }
        catch (Exception exception)
        {
            // for my junior colleague: here I Used preprocessor directives 
            //to conditionally compile code based on the configuration (Debug or Release).
#if DEBUG
            throw new Exception(exception.Message, exception.InnerException);
#else
                return BadRequest("An error occurred.please try again later");
#endif
        }
    }

    [HttpGet]
    [Route("get-calculated-tax-based-on-date-time-and-vehicle")]
    public async Task<IActionResult> GetGothenburgCalculatedTaxForSpesificDate([FromBody] CalculateByDateAndVehicleRequest request)
    {
        try
        {
            decimal totalFee = await _unitOfWork.DynamicTaxCalculator.GetTollFeeForDateTimeAsync(request.Date, request.Vehicle);
            if (totalFee > 60) totalFee = 60;
            CalculatedTax calculatedTax = new()
            {
                Date = request.Date,
                AmountOfDay = totalFee,
                MonetaryUnit = "SEK",
                City = "Gothenburg",
                Country = "Sweden",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            await _unitOfWork.DynamicTaxCalculator.AddAsync(calculatedTax);
            await _unitOfWork.CommitAsync();
            return Ok(calculatedTax);
        }
        catch (Exception exception)
        {
            // for my junior colleague: here I Used preprocessor directives 
            //to conditionally compile code based on the configuration (Debug or Release).
#if DEBUG
            throw new Exception(exception.Message, exception.InnerException);
#else
                return BadRequest("An error occurred.please try again later");
#endif
        }
    }

    #endregion


    #region Not Save In DataBase
    [HttpGet]
    [Route("get-tax-for-gothenburg")]
    public IActionResult GetTaxForGothenburg(VehicleType vehicle, DateTime[] dates)
    {
        try
        {
            DateTime intervalStart = dates[0];
            int totalFee = 0;
            foreach (DateTime date in dates)
            {
                int nextFee = _unitOfWork.StaticTaxCalculator.GetTollFee(date, vehicle);
                int tempFee = _unitOfWork.StaticTaxCalculator.GetTollFee(intervalStart, vehicle);

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
            return Ok(totalFee);
        }
        catch (Exception exception)
        {
#if DEBUG
            throw new Exception(exception.Message, exception.InnerException);
#else
            return BadRequest("An error occurred.please try again later");
#endif
        }
    }
    #endregion
}

