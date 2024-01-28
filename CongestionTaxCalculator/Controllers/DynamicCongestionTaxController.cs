using AutoMapper;
using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Enums;
using Calculator.Shared.Infrastructure.Pagination;
using Calculator.Shared.Infrastructure.Routes;
using Calculator.Shared.Models.DataTransferObjects;
using Calculator.Shared.Services.BaseAndConfigs;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Controllers;
[Route(CalculatorRotes.DynamicCalculator)]
[ApiController]
public class DynamicCongestionTaxController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    //    [HttpGet]
    //    [Route("get-calculated-tax-based-on-date-times")]
    //    public async Task<IActionResult> GetCalculatedTaxForSpesificDates(VehicleType vehicle, DateTime[] dates)
    //    {
    //        try
    //        {
    //            DateTime intervalStart = dates[0];
    //            int totalFee = await _unitOfWork.DynamicCalculatedTaxs.CalculateTotalFeeAsync(vehicle, dates, intervalStart);
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


    #region This Part is more for editors job / add/update/delete/get/ and more
    [HttpGet]
    [Route("get-calculated-tax-by-id/{id}")]
    public async Task<IActionResult> GetCalculatedTaxByIdAsync([FromRoute] int id)
    {
        try
        {
            CalculatedTax CalculatedTax = await _unitOfWork.DynamicTaxCalculator.GetCalculatedTaxByIdAsync(id);
            CalculatedTaxDto CalculatedTaxDto = _mapper.Map<CalculatedTaxDto>(CalculatedTax);
            return Ok(CalculatedTaxDto);
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
    [Route("get-calculated-tax-list")]
    public async Task<IActionResult> GetCalculatedTaxsAsync()
    {
        try
        {
            List<CalculatedTax> CalculatedTaxEntityList = await _unitOfWork.DynamicTaxCalculator.GetCalculatedTaxesAsync();
            List<CalculatedTaxDto> CalculatedTaxDtoList = _mapper.Map<List<CalculatedTaxDto>>(CalculatedTaxEntityList);
            return Ok(CalculatedTaxDtoList);
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

    // this method is created based on this scenario that maybe editors want to add some Calculated Tax to database themself
    [HttpPost]
    [Route("create-calculated-tax")]
    public async Task<IActionResult> CreateCalculatedTax([FromBody] CalculatedTaxDto dto)
    {
        try
        {
            CalculatedTax entity = _mapper.Map<CalculatedTax>(dto);
            await _unitOfWork.DynamicTaxCalculator.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return Ok(entity);
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

    // this method is created based on this scenario that maybe editors want to edit some Calculated Tax to database themself
    [HttpPut]
    [Route("update-calculated-tax/{id}")]
    public async Task<IActionResult> UpdateCalculatedTax([FromRoute] int id, [FromBody] CalculatedTaxDto dto)
    {
        try
        {
            bool isExist = await _unitOfWork.DynamicTaxCalculator.ExistsAsync(id);
            if (!isExist)
                return BadRequest($"there is not any CalculatedTax with this id: {id}");

            CalculatedTax entity = _mapper.Map<CalculatedTax>(dto);
            _unitOfWork.DynamicTaxCalculator.Update(entity);
            await _unitOfWork.CommitAsync();
            return Ok(entity);
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

    // this method is created based on this scenario that maybe editors want to delete some Calculated Tax from database themself
    [HttpDelete]
    [Route("delete-calculated-tax/{id}")]
    public async Task<IActionResult> DeleteCalculatedTax([FromRoute] int id)
    {
        try
        {
            bool isExist = await _unitOfWork.DynamicTaxCalculator.ExistsAsync(id);
            if (!isExist)
                return BadRequest($"there is not any Calculated Tax with this id: {id}");

            // for my junior colleague: here I used a trick this is very usefull in ef and MSSQL
            // when you want to delete an entity and you have the id, there is no need to get the entity
            // and then pass it to remove service, just build a new instance from your entity and put the id in it
            // then pass that to remove service. its will delete it. just like that, you improved your code speed
            CalculatedTax entity = new()
            {
                Id = id
            };
            _unitOfWork.DynamicTaxCalculator.Remove(entity);
            await _unitOfWork.CommitAsync();
            return Ok($"Calculated Tax Removed with this Id: {id}");
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
    [Route("get-paginated-calculated-taxes-by-filter")]
    public async Task<IActionResult> GetTCalculatedTaxesByFilter([FromRoute] DefaultPaginationFilter request)
    {
        try
        {
            List<CalculatedTax> CalculatedTaxList = await _unitOfWork.DynamicTaxCalculator.GetCalculatedTaxesByFilterAsync(request);

            List<CalculatedTaxDto> dtos = _mapper.Map<List<CalculatedTaxDto>>(CalculatedTaxList);

            PaginatedList<CalculatedTaxDto> result = new()
            {
                Page = request.Page,
                PageSize = request.PageSize,
                Data = dtos,
                TotalCount = dtos.Count
            };
            ;
            return Ok(result);
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
}
