using CalculadoraEstatisca.Domain;
using CalculadoraEstatisca.Domain.Interface;
using CalculadoraEstatisca.Domain.Service;
using CalculadoraEstatisca.Domain.Service.Average;
using CalculadoraEstatisca.Domain.Service.General;

namespace CalculadoraEstatisca.Api.Extensions;

public static class InjectionDependecyExtension
{
    public static IServiceCollection ConfigureInjectionDependecy(this IServiceCollection services)
    {
        services.AddScoped<ITableService, TableService>();
        services.AddScoped<IAverageService, AverageService>();
        services.AddScoped<IMedianService, MedianService>();
        services.AddScoped<IModeService, ModeService>();
        services.AddScoped<IStandardDeviationService, StandardDeviationService>();
        services.AddScoped<IStatisticalCalculatorService, StatisticalCalculatorService>();

        return services;
    }
}