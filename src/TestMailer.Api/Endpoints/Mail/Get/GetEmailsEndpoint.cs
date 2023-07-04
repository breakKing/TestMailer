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

        var task = response.Match(
            data => SendDataAsync(MapToApiResponse(data), ct: ct),
            errors => SendErrorsAsync(
                errors.Select(e => e.Description).ToList(),
                HttpStatusCode.BadRequest,
                ct));

        await task;
    }

    private static GetEmailsApiResponse MapToApiResponse(GetEmailsResponse response)
    {
        var items = response.Items
            .Select(e => new EmailItemApiDto(
                e.Subject,
                e.Body,
                e.Recipients))
            .ToList();

        return new GetEmailsApiResponse(items);
    }
}