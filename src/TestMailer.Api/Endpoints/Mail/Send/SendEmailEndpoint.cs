using System.Net;
using MediatR;
using TestMailer.Application.Mailing.SendEmail;

namespace TestMailer.Api.Endpoints.Mail.Send;

/// <summary>
/// Эндпоинт для отправки писем
/// </summary>
public sealed class SendEmailEndpoint : EndpointBase<SendEmailApiRequest, SendEmailApiResponse>
{
    private readonly ISender _sender;

    public SendEmailEndpoint(ISender sender)
    {
        _sender = sender;
    }

    /// <inheritdoc />
    public override void Configure()
    {
        Post("");
        Group<MailGroup>();
        AllowAnonymous();

        ConfigureSwaggerDescription(
            new SendEmailEndpointSummary(),
            HttpStatusCode.OK,
            HttpStatusCode.InternalServerError);
    }

    /// <inheritdoc />
    public override async Task HandleAsync(SendEmailApiRequest req, CancellationToken ct)
    {
        var command = new SendEmailCommand(
            req.Subject,
            req.Body,
            req.Recipients);

        var response = await _sender.Send(command, ct);
        
        await SendResponseAsync(response, _ => new(), ct);
    }
}