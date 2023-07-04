namespace TestMailer.Application.Mailing.GetEmails;

/// <summary>
/// Ответ с письмами
/// </summary>
/// <param name="Items">Список писем</param>
public sealed record GetEmailsResponse(List<EmailItemDto> Items);