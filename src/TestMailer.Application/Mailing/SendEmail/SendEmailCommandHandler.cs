using TestMailer.Application.Common.Handling;

namespace TestMailer.Application.Mailing.SendEmail;

/// <summary>
/// Обработчик команды по отправке письма
/// </summary>
internal sealed class SendEmailCommandHandler : ICommandHandler<SendEmailCommand>
{
    /// <inheritdoc />
    public async Task<Result<bool>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        return null;
    }
}