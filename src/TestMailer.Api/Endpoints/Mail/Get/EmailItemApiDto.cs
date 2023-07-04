namespace TestMailer.Api.Endpoints.Mail.Get;

/// <summary>
/// Dto для передачи информации о письме при выгрузке списка писем
/// </summary>
/// <param name="Subject">Тема</param>
/// <param name="Body">Тело</param>
/// <param name="Recipients">Получатели</param>
public sealed record EmailItemApiDto(
    string Subject,
    string Body,
    List<string> Recipients);