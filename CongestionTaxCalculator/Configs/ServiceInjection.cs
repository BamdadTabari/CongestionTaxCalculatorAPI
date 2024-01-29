using Calculator.Shared.EntityFramework.Configs;
using Calculator.Shared.Models.AutoMapperProfiles;
using Calculator.Shared.Services.BaseAndConfigs;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.Configs;

public static class ServiceInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {

        // Add services to the container.
        services.AddControllersWithViews();
        // register an HttpClient that points to itself
        services.AddSingleton(sp =>
        {
            // Get the address that the app is currently running at
            IServer? server = sp.GetRequiredService<IServer>();
            IServerAddressesFeature? addressFeature = server.Features.Get<IServerAddressesFeature>();
            string? baseAddress = addressFeature?.Addresses.First();
            return new HttpClient { BaseAddress = new Uri(baseAddress ?? "https://localhost:7247;http://localhost:5049") };
        });

        services.AddAutoMapper(typeof(TaxRulesAutoMapperProfiles));

        services.AddControllers();

        // this fluent validation => AddFluentValidationAutoValidation(): This method adds automatic validation to your application.
        // sets up FluentValidation to automatically validate data models whenever they are used in your application.
        //AddFluentValidationClientsideAdapters(): This method adds client - side adapters for FluentValidation.
        //These adapters would allow you to use FluentValidation rules on the client side(in the browser)
        //to provide real - time feedback to users before they submit forms.
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("ServerDbConnection"))
        .EnableDetailedErrors());
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}