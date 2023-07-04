using System.Text.Json;
using FastEndpoints.Swagger;
using TestMailer.Api.Endpoints;

namespace TestMailer.Api.Configuration;

public static class ApplicationPipeline
{
    /// <summary>
    /// Конфигурация пайплайна (миддлваров) приложения
    /// </summary>
    /// <param name="app">Экземпляр приложения</param>
    /// <returns></returns>
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseHttpsRedirection();

        app.UseFastEndpoints(config =>
        {
            config.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            config.Endpoints.RoutePrefix = "api";
            
            config.Errors.ResponseBuilder = (failures, _, _) =>
            {
                return new ApiResponse<object>(
                    null, 
                    true,
                    failures.Select(f => $"{f.PropertyName}: {f.ErrorMessage}").ToList());
            };
        });
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerGen();
        }
        
        return app;
    }
}