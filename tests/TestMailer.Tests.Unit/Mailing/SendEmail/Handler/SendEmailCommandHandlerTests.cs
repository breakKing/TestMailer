using System.Collections.ObjectModel;
using FluentAssertions;
using TestMailer.Application.Mailing.SendEmail;

namespace TestMailer.Tests.Unit.Mailing.SendEmail.Handler;

public class SendEmailCommandHandlerTests
{
    [Fact]
    public async Task Handler_ShouldWriteAndReturnError_WhenEmailFailedToBeSent()
    {
        // Arrange
        var writeRepoMock = new EmailWriteRepoMock();
        var emailServiceMock = new EmailServiceMock(true);

        var handler = new SendEmailCommandHandler(writeRepoMock, emailServiceMock);
        
        // Act
        var command = new SendEmailCommand(
            "Test subject", 
            "Test message", 
            new [] { "test@example.com" });

        var response = await handler.Handle(command, CancellationToken.None);

        // Assert
        response.IsError
            .Should()
            .BeTrue();
        
        response.Errors
            .Should()
            .OnlyContain(e => 
                e.Code == EmailServiceMock.FailErrorCode && e.Description == EmailServiceMock.FailErrorMessage);
    }
    
    [Fact]
    public async Task Handler_ShouldReturnOkResult_WhenEmailIsSuccessfullySent()
    {
        // Arrange
        var writeRepoMock = new EmailWriteRepoMock();
        var emailServiceMock = new EmailServiceMock();

        var handler = new SendEmailCommandHandler(writeRepoMock, emailServiceMock);
        
        // Act
        var command = new SendEmailCommand(
            "Test subject", 
            "Test message", 
            new [] { "test@example.com" });

        var response = await handler.Handle(command, CancellationToken.None);

        // Assert
        response.IsError
            .Should()
            .BeFalse();
    }
}