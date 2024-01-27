using CongestionTaxCalculator.Configs;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json")
            .AddEnvironmentVariables();

ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

// Add services to the container.
builder.Services.AddServices(configuration);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseConfiguredExceptionHandler(environment);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();

app.Run();
