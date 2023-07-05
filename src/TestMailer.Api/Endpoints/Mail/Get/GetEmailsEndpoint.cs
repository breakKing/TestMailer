using System.Net;
using MediatR;
using TestMailer.Application.Mailing.GetEmails;

namespace TestMailer.Api.Endpoints.Mail.Get;

/// <summary>
/// Эндпоинт для получения списка писем
/// </summary>
public sealed class GetEmailsEndpoint : EndpointWithoutRequestBase<GetEmailsApiResponse>
{
    private readonly ISender _sender;

    public GetEmailsEndpoint(ISender sender)
    {
        _sender = sender;
    }

    /// <inheritdoc />
    public override void Configure()
    {
        Get("");
        Group<MailGroup>();
        AllowAnonymous();

        ConfigureSwaggerDescription(
            new GetEmailsEndpointSummary(),
            HttpStatusCode.OK,
            HttpStatusCode.InternalServerError);
    }

    /// <inheritdoc />
    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var query = new GetEmailsQuery();
        
        var response = await _sender.Send(query, ct);

        await SendResponseAsync(response, MapToApiResponse, ct);
    }

    private static GetEmailsApiResponse MapToApiResponse(GetEmailsResponse response)
    {
        var items = response.Items
            .Select(e => new EmailItemApiDto(
                e.Subject,
                e.Body,
                e.Recipients,
                e.CreatedAt,
                e.Result.ToString(),
                e.FailedMessage))
            .ToList();

        return new GetEmailsApiResponse(items);
    }
}