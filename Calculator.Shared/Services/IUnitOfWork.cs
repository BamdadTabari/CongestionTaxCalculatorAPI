using Calculator.Shared.Services.Interfaces;

namespace Calculator.Shared.Services;

public interface IUnitOfWork : IDisposable
{
    IDynamicTaxRulesService DynamicTaxRules { get; }
    IStaticTaxCalculatorService StaticTaxCalculaotr { get; }

    Task<bool> CommitAsync();
}