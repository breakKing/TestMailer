namespace TestMailer.Api.Endpoints.Mail.Get;

/// <summary>
/// Dto для передачи информации о письме при выгрузке списка писем
/// </summary>
/// <param name="Subject">Тема</param>
/// <param name="Body">Тело</param>
/// <param name="Recipients">Получатели</param>
/// <param name="CreatedAt">Дата создания и отправки</param>
/// <param name="Result">Результат отправки</param>
/// <param name="FailedMessage">Описание ошибки (если есть)</param>
public sealed record EmailItemApiDto(
    string Subject,
    string Body,
    List<string> Recipients,
    DateTimeOffset CreatedAt,
    string Result,
    string? FailedMessage);