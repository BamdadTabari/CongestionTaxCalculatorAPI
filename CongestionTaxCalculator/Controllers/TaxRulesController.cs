using AutoMapper;
using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Infrastructure.Pagination;
using Calculator.Shared.Infrastructure.Routes;
using Calculator.Shared.Models.DataTransferObjects;
using Calculator.Shared.Services.BaseAndConfigs;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Controllers;

// this type of constructors that I used here and in most classes in project called primary-constructors
// allows you to have a constructor in an easier way making your code cleaner
// the learning source https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors
[Route(CalculatorRotes.TaxRules)]
[ApiController]
public class TaxRulesController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    [Route("get-tax-rule-by-id/{id}")]
    public async Task<IActionResult> GetTaxRuleByIdAsync([FromRoute] int id)
    {
        try
        {
            TaxRule taxRule = await _unitOfWork.TaxRules.GetTaxRuleByIdAsync(id);
            TaxRuleDto taxRuleDto = _mapper.Map<TaxRuleDto>(taxRule);
            return Ok(taxRuleDto);
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
    [Route("get-tax-rule-list")]
    public async Task<IActionResult> GetTaxRulesAsync()
    {
        try
        {
            List<TaxRule> taxRuleEntityList = await _unitOfWork.TaxRules.GetTaxRulesAsync();
            List<TaxRuleDto> taxRuleDtoList = _mapper.Map<List<TaxRuleDto>>(taxRuleEntityList);
            return Ok(taxRuleDtoList);
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

    [HttpPost]
    [Route("create-tax-rule")]
    public async Task<IActionResult> CreateTaxRule([FromBody] TaxRuleDto dto)
    {
        try
        {
            TaxRule entity = _mapper.Map<TaxRule>(dto);
            await _unitOfWork.TaxRules.AddAsync(entity);
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


    [HttpPut]
    [Route("update-tax-rule/{id}")]
    public async Task<IActionResult> UpdateTaxRole([FromRoute] int id, [FromBody] TaxRuleDto dto)
    {
        try
        {
            bool isExist = await _unitOfWork.TaxRules.ExistsAsync(id);
            if (!isExist)
                return BadRequest($"there is not any Tax Rule with this id: {id}");

            TaxRule entity = _mapper.Map<TaxRule>(dto);
            _unitOfWork.TaxRules.Update(entity);
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

    [HttpDelete]
    [Route("delete-tax-rule/{id}")]
    public async Task<IActionResult> DeleteTaxRole([FromRoute] int id)
    {
        try
        {
            bool isExist = await _unitOfWork.TaxRules.ExistsAsync(id);
            if (!isExist)
                return BadRequest($"there is not any Tax Rule with this id: {id}");

            // for my junior colleague: here I used a trick this is very usefull in ef and MSSQL
            // when you want to delete an entity and you have the id, there is no need to get the entity
            // and then pass it to remove service, just build a new instance from your entity and put the id in it
            // then pass that to remove service. its will delete it. just like that, you improved your code speed
            TaxRule entity = new()
            {
                Id = id
            };
            _unitOfWork.TaxRules.Remove(entity);
            await _unitOfWork.CommitAsync();
            return Ok($"Tax Rule Removed with this Id: {id}");
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
    [Route("get-paginated-tax-rules-by-filter")]
    public async Task<IActionResult> GetTaxRolesByFilter([FromRoute] DefaultPaginationFilter request)
    {
        try
        {
            List<TaxRule> taxRuleList = await _unitOfWork.TaxRules.GetTaxRulesByFilterAsync(request);

            List<TaxRuleDto> dtos = _mapper.Map<List<TaxRuleDto>>(taxRuleList);

            PaginatedList<TaxRuleDto> result = new()
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
}