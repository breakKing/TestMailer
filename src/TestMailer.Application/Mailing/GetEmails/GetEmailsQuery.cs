using TestMailer.Application.Common.Handling;

namespace TestMailer.Application.Mailing.GetEmails;

/// <summary>
/// Запрос на выгрузку информации о письмах
/// </summary>
public sealed record GetEmailsQuery : IQuery<GetEmailsResponse>;