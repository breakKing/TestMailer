using ErrorOr;
using TestMailer.Application.Mailing;
using TestMailer.Domain.Mailing;

namespace TestMailer.Tests.Unit.Mailing.SendEmail;

internal sealed class EmailServiceMock : IEmailService
{
    internal const string FailErrorCode = "Email.Test.Error";
    internal const string FailErrorMessage = "Test fail message";
    
    private readonly bool _shouldFail;
    
    internal EmailServiceMock(bool shouldFail = false)
    {
        _shouldFail = shouldFail;
    }
    
    /// <inheritdoc />
    public Task<ErrorOr<bool>> SendEmailAsync(Email email, CancellationToken ct = default)
    {
        return _shouldFail ? 
            Task.FromResult<ErrorOr<bool>>(Error.Failure(FailErrorCode, FailErrorMessage)) : 
            Task.FromResult<ErrorOr<bool>>(true);
    }
}