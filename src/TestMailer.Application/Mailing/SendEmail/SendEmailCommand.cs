using TestMailer.Application.Common.Handling;

namespace TestMailer.Application.Mailing.SendEmail;

/// <summary>
/// Команда на отправку письма
/// </summary>
/// <param name="Subject">Тема</param>
/// <param name="Body">Тело</param>
/// <param name="Recipients">Получатели</param>
public sealed record SendEmailCommand(
    string Subject,
    string Body,
    IReadOnlyList<string> Recipients) : ICommand;