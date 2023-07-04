using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestMailer.Application.Common.DataAccess;
using TestMailer.Application.Mailing;
using TestMailer.Infrastructure.Emailing;
using TestMailer.Infrastructure.Persistence;
using TestMailer.Infrastructure.Persistence.Repositories;

namespace TestMailer.Infrastructure;

/// <summary>
/// Конфигурация требуемых сервисов
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Основной метод по добавлению сервисов уровня инфраструктуры
    /// </summary>
    /// <param name="services">Контейнер сервисов</param>
    /// <param name="configuration">Конфигурация</param>
    /// <returns>Контейнер сервисов с добавленными сервисами</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MailingDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("Database"),
                npgsql =>
                {
                    npgsql.MigrationsHistoryTable("migrations_history", "Migrations");
                });

            options.UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IEmailReadRepository, EmailReadRepository>();
        services.AddScoped<IEmailWriteRepository, EmailWriteRepository>();

        services.AddScoped<IUnitOfWork, MailingDbContext>();

        services.AddOptions<SmtpConfiguration>()
            .BindConfiguration(SmtpConfiguration.SectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}