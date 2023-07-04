using TestMailer.Domain.Mailing;

namespace TestMailer.Application.Mailing;

/// <summary>
/// Репозиторий для записи писем
/// </summary>
public interface IEmailWriteRepository
{
    /// <summary>
    /// Добавление нового письма
    /// </summary>
    /// <param name="email">Сущность письма</param>
    /// <returns></returns>
    Task Add(Email email);
}