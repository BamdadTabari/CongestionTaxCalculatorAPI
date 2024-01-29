using Calculator.Shared.Services.Interfaces;

namespace Calculator.Shared.Services.BaseAndConfigs;

public interface IUnitOfWork : IDisposable
{
    ITaxRulesService TaxRules { get; }
    IBaseRuleService BaseRules { get; }
    IStaticTaxCalculatorService StaticTaxCalculator { get; }
    IDynamicTaxCalculatorService DynamicTaxCalculator { get; }

    Task<bool> CommitAsync();
}