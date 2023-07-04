namespace TestMailer.Api.Endpoints.Mail;

/// <summary>
/// Группа эндпоинтов для работы с письмами
/// </summary>
public sealed class MailGroup : EndpointGroupBase
{
    /// <inheritdoc />
    public MailGroup() : base("Mail", "mails")
    {
    }
}