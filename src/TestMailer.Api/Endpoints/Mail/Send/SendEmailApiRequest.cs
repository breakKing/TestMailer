namespace TestMailer.Api.Endpoints.Mail.Send;

/// <summary>
/// Запрос на отправку электронного письма
/// </summary>
/// <param name="Subject">Тема</param>
/// <param name="Body">Тело</param>
/// <param name="Recipients">Получатели</param>
public sealed record SendEmailApiRequest(string Subject, string Body, IReadOnlyList<string> Recipients);