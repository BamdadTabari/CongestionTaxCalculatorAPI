using Calculator.Shared.Services.Interfaces;

namespace Calculator.Shared.Services;

public interface IUnitOfWork : IDisposable
{
    IDynamicTaxRulesService DynamicTaxRules { get; }
    IStaticTaxRulesService StaticTaxRules { get; }

    Task<bool> CommitAsync();
}