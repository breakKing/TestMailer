using ErrorOr;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using TestMailer.Application.Common.Handling;
using TestMailer.Application.Mailing;
using TestMailer.Application.Mailing.SendEmail;
using TestMailer.Domain.Mailing;

namespace TestMailer.Infrastructure.Emailing;

/// <inheritdoc />
internal sealed class EmailService : IEmailService
{
    private readonly SmtpConfiguration _smtpConfig;

    public EmailService(IOptions<SmtpConfiguration> smtp)
    {
        _smtpConfig = smtp.Value;
    }

    /// <inheritdoc />
    public async Task<ErrorOr<bool>> SendEmailAsync(Email email, CancellationToken ct = default)
    {
        try
        {
            var mimeMessage = FormMimeMessageSenderAndRecipients(email);
            
            FormMimeMessageSubjectAndBody(email, mimeMessage);

            await SendViaSmtpAsync(mimeMessage, ct);

            return true;
        }
        catch (Exception ex)
        {
            var error = Error.Failure(SendEmailErrors.Code, ex.Message);
            return error;
        }
    }

    private MimeMessage FormMimeMessageSenderAndRecipients(Email email)
    {
        var mimeMessage = new MimeMessage();
        var senderAddress = new MailboxAddress(_smtpConfig.DisplayName, _smtpConfig.From);
            
        mimeMessage.From.Add(senderAddress);
        mimeMessage.Sender = senderAddress;
            
        foreach (var recipient in email.Recipients)
        {
            var address = MailboxAddress.Parse(recipient);
            mimeMessage.To.Add(address);
        }
        
        return mimeMessage;
    }

    private static void FormMimeMessageSubjectAndBody(Email email, MimeMessage mimeMessage)
    {
        mimeMessage.Subject = email.Subject;
        
        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = email.Body
        };
        
        mimeMessage.Body = bodyBuilder.ToMessageBody();
    }

    private async Task SendViaSmtpAsync(MimeMessage mimeMessage, CancellationToken ct = default)
    {
        using var smtp = new SmtpClient();

        if (_smtpConfig.UseSsl)
        {
            await smtp.ConnectAsync(_smtpConfig.Host, _smtpConfig.Port, SecureSocketOptions.SslOnConnect, ct);
        }
        else if (_smtpConfig.UseStartTls)
        {
            await smtp.ConnectAsync(_smtpConfig.Host, _smtpConfig.Port, SecureSocketOptions.StartTls, ct);
        }

        await smtp.AuthenticateAsync(_smtpConfig.UserName, _smtpConfig.Password, ct);
        await smtp.SendAsync(mimeMessage, ct);
        await smtp.DisconnectAsync(true, ct);
    }
}