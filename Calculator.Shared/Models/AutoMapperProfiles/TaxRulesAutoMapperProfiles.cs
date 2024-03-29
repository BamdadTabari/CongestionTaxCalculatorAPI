﻿using AutoMapper;
using Calculator.Shared.EntityFramework.Entities.TaxEntities;
using Calculator.Shared.Models.DataTransferObjects;

namespace Calculator.Shared.Models.AutoMapperProfiles;
public class TaxRulesAutoMapperProfiles : Profile
{
    public TaxRulesAutoMapperProfiles()
    {
        CreateMap<TaxRule, TaxRuleDto>().ReverseMap();
        CreateMap<BaseRule, BaseRuleDto>().ReverseMap();
        CreateMap<CalculatedTax, CalculatedTaxDto>().ReverseMap();
    }
}
