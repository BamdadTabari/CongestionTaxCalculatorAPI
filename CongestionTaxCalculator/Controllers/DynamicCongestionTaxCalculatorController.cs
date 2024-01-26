using AutoMapper;
using Calculator.Shared.Enums;
using Calculator.Shared.Infrastructure.Routes;
using Calculator.Shared.Models.DataTransferObjects;
using Calculator.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Controllers;
[Route(CalculatorRotes.DynamicCalculator)]
[ApiController]
public class DynamicCongestionTaxCalculatorController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    [Route("get-tax-based-on-date-times")]
    public async Task<int> GetCalculatedTaxForSpesificDates(VehicleType vehicle, DateTime[] dates)
    {
        DateTime intervalStart = dates[0];
        int totalFee = await _unitOfWork.DynamicTaxRules.CalculateTotalFeeAsync(vehicle, dates, intervalStart);
        if (totalFee > 60) totalFee = 60;
        return totalFee;
    }

    [HttpGet]
    [Route("get-tax-rule-list")]
    public async Task<List<TaxRuleDto>> GetTaxRulesAsync()
    {
        var taxRuleEntityList = await _unitOfWork.DynamicTaxRules.GetTaxRulesAsync();
        var taxRuleDtoList = _mapper.Map<List<TaxRuleDto>>(taxRuleEntityList);
        return taxRuleDtoList;
    }
}