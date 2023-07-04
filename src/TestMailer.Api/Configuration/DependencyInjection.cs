using System.Text.Json;
using System.Text.Json.Serialization;
using FastEndpoints.Swagger;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NJsonSchema;
using TestMailer.Application;
using TestMailer.Infrastructure;

namespace TestMailer.Api.Configuration;

public static class DependencyInjection
{
    /// <summary>
    /// Конфигурация сервисов в DI-контейнере
    /// </summary>
    /// <param name="builder">Экземпляр билдера приложения</param>
    /// <returns></returns>
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddFastEndpoints();
        
        builder.Services.SwaggerDocument(o =>
        {
            o.EnableJWTBearerAuth = false;
            
            o.DocumentSettings = settings =>
            {
                settings.Title = "TestMailer";
                settings.Version = "v1";
                settings.SchemaType = SchemaType.OpenApi3;
                settings.MarkNonNullablePropsAsRequired();
                settings.AllowNullableBodyParameters = true;
                settings.GenerateEnumMappingDescription = true;
                settings.SerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
            };

            o.SerializerSettings = s =>
            {
                s.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                s.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                s.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            };

            o.ShortSchemaNames = true;
        });

        builder.Services
            .AddApplication()
            .AddInfrastructure(builder.Configuration);

        return builder;
    }
}