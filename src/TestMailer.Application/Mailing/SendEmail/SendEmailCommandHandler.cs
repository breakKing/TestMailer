using TestMailer.Application.Common.Handling;
using TestMailer.Domain.Mailing;

namespace TestMailer.Application.Mailing.SendEmail;

/// <summary>
/// Обработчик команды по отправке письма
/// </summary>
internal sealed class SendEmailCommandHandler : ICommandHandler<SendEmailCommand>
{
    private readonly IEmailWriteRepository _repository;
    private readonly IEmailService _emailService;

    public SendEmailCommandHandler(IEmailWriteRepository repository, IEmailService emailService)
    {
        _repository = repository;
        _emailService = emailService;
    }

    /// <inheritdoc />
    public async Task<Result<bool>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        var email = new Email(
            request.Subject,
            request.Body,
            request.Recipients);

        var sendResult = await _emailService.SendEmailAsync(email, cancellationToken);

        sendResult.Switch(
            _ => email.MarkAsSent(),
            errors => email.MarkAsFailed(errors.FirstOrDefault()?.Description ?? string.Empty));
        
        _repository.Add(email);

        return Result<bool>.Success(true);
    }
}