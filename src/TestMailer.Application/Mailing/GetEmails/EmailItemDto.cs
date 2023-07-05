using TestMailer.Domain.Mailing;

namespace TestMailer.Application.Mailing.GetEmails;

/// <summary>
/// Возвращаемая информация по письму
/// </summary>
/// <param name="Subject">Тема</param>
/// <param name="Body">Тело</param>
/// <param name="Recipients">Получатели</param>
/// <param name="CreatedAt">Дата создания и отправки</param>
/// <param name="Result">Результат отправки</param>
/// <param name="FailedMessage">Описание ошибки (если есть)</param>
public sealed record EmailItemDto(
    string Subject,
    string Body,
    List<string> Recipients,
    DateTimeOffset CreatedAt,
    EmailResult Result,
    string? FailedMessage);