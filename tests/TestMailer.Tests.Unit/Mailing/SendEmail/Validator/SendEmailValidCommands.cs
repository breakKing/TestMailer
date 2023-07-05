using TestMailer.Application.Mailing.SendEmail;

namespace TestMailer.Tests.Unit.Mailing.SendEmail.Validator;

internal sealed class SendEmailValidCommands : TheoryData<SendEmailCommand>
{
    public SendEmailValidCommands()
    {
        Add(new SendEmailCommand(
            "Subject",
            "This is the body",
            new [] { "test@example.com" }));
        
        Add(new SendEmailCommand(
            "Subject",
            "This is the body",
            new [] { "test@example.com", "test2@example.com", "test@sample.net" }));
    }
}