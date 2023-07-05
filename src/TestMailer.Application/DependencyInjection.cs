using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TestMailer.Application.Common.Pipeline;

namespace TestMailer.Application;

/// <summary>
/// Конфигурация требуемых сервисов
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Основной метод по добавлению сервисов уровня приложнения
    /// </summary>
    /// <param name="services">Контейнер сервисов</param>
    /// <returns>Контейнер сервисов с добавленными сервисами</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining<IApplicationAssemblyMarker>();
            
            options.AddOpenBehavior(typeof(ExceptionHandlerPipelineBehavior<,>));
            options.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
            options.AddOpenBehavior(typeof(UnitOfWorkPipelineBehavior<,>));
        });

        services.AddValidatorsFromAssemblyContaining<IApplicationAssemblyMarker>();

        return services;
    }
}