﻿namespace TestMailer.Api;

public static class DependencyInjection
{
    /// <summary>
    /// Конфигурация сервисов в DI-контейнере
    /// </summary>
    /// <param name="builder">Экземпляр билдера приложения</param>
    /// <returns></returns>
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        
        builder.Services.AddSwaggerGen();

        return builder;
    }
}