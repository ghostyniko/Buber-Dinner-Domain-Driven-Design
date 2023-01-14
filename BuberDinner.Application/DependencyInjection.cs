using System.Reflection;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Behavoirs;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ErrorOr;
using FluentValidation;
using BuberDinner.Application.Common.Mapping;

namespace BuberDinner.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).GetTypeInfo().Assembly);

        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehaviour<,>));
        services.AddMappings();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}