using TestMailer.Application.Common.Pagination;

namespace TestMailer.Application.Mailing.GetEmails;

public sealed record GetEmailsResponse(PagedList<EmailItemDto> Emails);