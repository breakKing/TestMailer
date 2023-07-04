namespace TestMailer.Application.Mailing.GetEmails;

public sealed record EmailItemDto(
    string Subject,
    string Body,
    List<string> Recipients);