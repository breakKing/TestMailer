using TestMailer.Application.Mailing;
using TestMailer.Domain.Mailing;

namespace TestMailer.Tests.Unit.Mailing.SendEmail;

internal sealed class EmailWriteRepoMock : IEmailWriteRepository
{
    internal List<Email> Emails { get; } = new();

    /// <inheritdoc />
    public void Add(Email email)
    {
        Emails.Add(email);
    }
}