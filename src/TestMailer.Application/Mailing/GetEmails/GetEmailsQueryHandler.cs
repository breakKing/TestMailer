using TestMailer.Application.Common.Handling;

namespace TestMailer.Application.Mailing.GetEmails;

public sealed class GetEmailsQueryHandler : IQueryHandler<GetEmailsQuery, GetEmailsResponse>
{
    /// <inheritdoc />
    public async Task<Result<GetEmailsResponse>> Handle(GetEmailsQuery request, CancellationToken cancellationToken)
    {
        return null;
    }
}