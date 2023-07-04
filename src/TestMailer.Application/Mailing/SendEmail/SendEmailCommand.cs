using TestMailer.Application.Common.Handling;

namespace TestMailer.Application.Mailing.SendEmail;

public sealed record SendEmailCommand(
    string Subject,
    string Body,
    List<string> Recipients) : ICommand;