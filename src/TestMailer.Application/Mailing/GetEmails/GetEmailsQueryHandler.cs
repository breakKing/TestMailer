using TestMailer.Application.Common.Handling;

namespace TestMailer.Application.Mailing.GetEmails;

/// <summary>
/// Обработчик запроса на выгрузку писем
/// </summary>
public sealed class GetEmailsQueryHandler : IQueryHandler<GetEmailsQuery, GetEmailsResponse>
{
    private readonly IEmailReadRepository _repository;

    public GetEmailsQueryHandler(IEmailReadRepository repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public async Task<Result<GetEmailsResponse>> Handle(GetEmailsQuery request, CancellationToken cancellationToken)
    {
        var data = await _repository.GetListAsync(cancellationToken);

        var response = new GetEmailsResponse(data);

        return Result<GetEmailsResponse>.Success(response);
    }
}