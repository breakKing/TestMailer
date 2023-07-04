﻿using Microsoft.Extensions.DependencyInjection;

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
        return services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining<IApplicationAssemblyMarker>();
        });
    }
}