using BuberDinner.Api.Common.Mapping;
using BuberDinner.Api.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Api;
public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, BubberDinnerProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}