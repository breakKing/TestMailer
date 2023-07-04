using TestMailer.Application.Common.Handling;

namespace TestMailer.Application.Mailing.SendEmail;

public sealed class SendEmailCommandHandler : ICommandHandler<SendEmailCommand>
{
    /// <inheritdoc />
    public async Task<Result<bool>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        return null;
    }
}