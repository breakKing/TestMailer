namespace TestMailer.Application.Mailing.GetEmails;

/// <summary>
/// Возвращаемая информация по письму
/// </summary>
/// <param name="Subject">Тема</param>
/// <param name="Body">Тело</param>
/// <param name="Recipients">Получатели</param>
public sealed record EmailItemDto(
    string Subject,
    string Body,
    List<string> Recipients);