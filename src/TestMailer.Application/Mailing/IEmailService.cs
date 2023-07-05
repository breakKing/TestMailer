using ErrorOr;
using TestMailer.Domain.Mailing;

namespace TestMailer.Application.Mailing;

/// <summary>
/// Сервис по управлению отправками писем
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Отправка электронного письма
    /// </summary>
    /// <param name="email">Сущность письма</param>
    /// <param name="ct">Токен отмены</param>
    /// <returns>Результат отправки с описанием ошибки (если есть)</returns>
    Task<ErrorOr<bool>> SendEmailAsync(Email email, CancellationToken ct = default);
}