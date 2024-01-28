using Calculator.Shared.Services.Interfaces;

namespace Calculator.Shared.Services.BaseAndConfigs;

public interface IUnitOfWork : IDisposable
{
    ITaxRulesService TaxRules { get; }
    IStaticTaxCalculatorService StaticTaxCalculaotr { get; }

    Task<bool> CommitAsync();
}