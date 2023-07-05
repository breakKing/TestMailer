using TestMailer.Application.Mailing.SendEmail;

namespace TestMailer.Tests.Unit.Mailing.SendEmail.Validator;

internal sealed class SendEmailInvalidCommands : TheoryData<SendEmailCommand>
{
    public SendEmailInvalidCommands()
    {
        Add(new SendEmailCommand(
            "",
            "This is the body",
            new [] { "test@example.com" }));

        Add(new SendEmailCommand(
            "Subject",
            "",
            new [] { "test@example.com" }));
        
        Add(new SendEmailCommand(
            "Subject",
            "This is the body",
            Array.Empty<string>()));
        
        Add(new SendEmailCommand(
            "Subject",
            "This is the body",
            new [] { "wrong_email" }));
    }
}