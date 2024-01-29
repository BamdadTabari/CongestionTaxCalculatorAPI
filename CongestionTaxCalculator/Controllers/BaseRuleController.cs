using AutoMapper;
using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Infrastructure.Pagination;
using Calculator.Shared.Infrastructure.Routes;
using Calculator.Shared.Models.DataTransferObjects;
using Calculator.Shared.Models.RequestModels;
using Calculator.Shared.Services.BaseAndConfigs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Controllers;
[Route(CalculatorRotes.BaseRules)]
[ApiController]
public class BaseRuleController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    #region This Part is more for editors job / add/update/delete/get/ and more
    [HttpGet]
    [Route("get-base-rule-by-id/{id}")]
    public async Task<IActionResult> GetBaseRuleByIdAsync([FromRoute] int id)
    {
        try
        {
            BaseRule BaseRule = await _unitOfWork.BaseRules.GetBaseRuleByIdAsync(id);
            BaseRuleDto BaseRuleDto = _mapper.Map<BaseRuleDto>(BaseRule);
            return Ok(BaseRuleDto);
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
    [Route("get-base-rule-list")]
    public async Task<IActionResult> GetBaseRulesAsync()
    {
        try
        {
            List<BaseRule> BaseRuleEntityList = await _unitOfWork.BaseRules.GetBaseRulesAsync();
            List<BaseRuleDto> BaseRuleDtoList = _mapper.Map<List<BaseRuleDto>>(BaseRuleEntityList);
            return Ok(BaseRuleDtoList);
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

    // this method is created based on this scenario that maybe editors want to add some Base Rule to database themself
    [HttpPost]
    [Route("create-base-rule")]
    public async Task<IActionResult> CreateBaseRule([FromBody] BaseRuleDto dto)
    {
        try
        {
            BaseRule entity = _mapper.Map<BaseRule>(dto);
            await _unitOfWork.BaseRules.AddAsync(entity);
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

    // this method is created based on this scenario that maybe editors want to edit some Base Rule to database themself
    [HttpPut]
    [Route("update-base-rule/{id}")]
    public async Task<IActionResult> UpdateBaseRule([FromRoute] int id, [FromBody] BaseRuleDto dto)
    {
        try
        {
            bool isExist = await _unitOfWork.BaseRules.ExistsAsync(id);
            if (!isExist)
                return BadRequest($"there is not any BaseRule with this id: {id}");

            BaseRule entity = _mapper.Map<BaseRule>(dto);
            _unitOfWork.BaseRules.Update(entity);
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

    // this method is created based on this scenario that maybe editors want to delete some Base Rule from database themself
    [HttpDelete]
    [Route("delete-base-rule/{id}")]
    public async Task<IActionResult> DeleteBaseRule([FromRoute] int id)
    {
        try
        {
            bool isExist = await _unitOfWork.BaseRules.ExistsAsync(id);
            if (!isExist)
                return BadRequest($"there is not any Base Rule with this id: {id}");

            // for my junior colleague: here I used a trick this is very usefull in ef and MSSQL
            // when you want to delete an entity and you have the id, there is no need to get the entity
            // and then pass it to remove service, just build a new instance from your entity and put the id in it
            // then pass that to remove service. its will delete it. just like that, you improved your code speed
            BaseRule entity = new()
            {
                Id = id
            };
            _unitOfWork.BaseRules.Remove(entity);
            await _unitOfWork.CommitAsync();
            return Ok($"Base Rule Removed with this Id: {id}");
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
    [Route("get-paginated-base-rulees-by-filter")]
    public async Task<IActionResult> GetTBaseRuleesByFilter([FromRoute] BaseRulePaginationFilter request)
    {
        try
        {
            List<BaseRule> BaseRuleList = await _unitOfWork.BaseRules.GetBaseRulesByFilterAsync(request);

            List<BaseRuleDto> dtos = _mapper.Map<List<BaseRuleDto>>(BaseRuleList);

            PaginatedList<BaseRuleDto> result = new()
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