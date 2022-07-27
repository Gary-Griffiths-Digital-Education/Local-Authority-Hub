using System.Reflection;
using Application.Common.Behaviours;
using Application.Common.Mappings;
using Application.Models.DtoEntities;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMappingProfiles());
        });

        var mapper = config.CreateMapper();
        services.AddSingleton(mapper);

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

        return services;
    }

    public static IServiceCollection AddWebUIApplicationServices(this IServiceCollection services)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMappingProfiles());
        });

        var mapper = config.CreateMapper();
        services.AddSingleton(mapper);

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
