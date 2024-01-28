using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Enums;
using Calculator.Shared.Infrastructure.Routes;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Controllers;
[Route(CalculatorRotes.DynamicCalculator)]
[ApiController]
public class DynamicCongestionTaxController : ControllerBase
{

    //    [HttpGet]
    //    [Route("get-tax-rule-based-on-date-times")]
    //    public async Task<IActionResult> GetCalculatedTaxForSpesificDates(VehicleType vehicle, DateTime[] dates)
    //    {
    //        try
    //        {
    //            DateTime intervalStart = dates[0];
    //            int totalFee = await _unitOfWork.DynamicTaxRules.CalculateTotalFeeAsync(vehicle, dates, intervalStart);
    //            if (totalFee > 60) totalFee = 60;
    //            return Ok(totalFee);
    //        }
    //        catch (Exception exception)
    //        {
    //            // for my junior colleague: here I Used preprocessor directives 
    //            //to conditionally compile code based on the configuration (Debug or Release).
    //#if DEBUG
    //            throw new Exception(exception.Message, exception.InnerException);
    //#else
    //            return BadRequest("An error occurred.please try again later");
    //#endif
    //        }
    //    }


   
}
