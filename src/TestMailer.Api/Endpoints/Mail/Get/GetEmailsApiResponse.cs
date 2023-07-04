namespace TestMailer.Api.Endpoints.Mail.Get;

/// <summary>
/// Ответ при выгрузке писем из БД
/// </summary>
/// <param name="Items">Список писем, выгруженных из БД</param>
public sealed record GetEmailsApiResponse(List<EmailItemApiDto> Items);