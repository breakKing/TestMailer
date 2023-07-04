using TestMailer.Application.Mailing.GetEmails;

namespace TestMailer.Application.Mailing;

/// <summary>
/// Репозиторий для выгрузки писем
/// </summary>
public interface IEmailReadRepository
{
    /// <summary>
    /// Получение списка писем
    /// </summary>
    /// <param name="ct">Токен отмены</param>
    /// <returns></returns>
    Task<IReadOnlyList<EmailItemDto>> GetListAsync(CancellationToken ct = default);
}