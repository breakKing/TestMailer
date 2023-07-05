using FluentAssertions;
using FluentValidation;
using TestMailer.Application.Mailing.SendEmail;

namespace TestMailer.Tests.Unit.Mailing.SendEmail.Validator;

public class SendEmailCommandValidatorTests
{
    private readonly SendEmailCommandValidator _validator;

    public SendEmailCommandValidatorTests()
    {
        _validator = new SendEmailCommandValidator();
    }

    [Theory]
    [ClassData(typeof(SendEmailInvalidCommands))]
    public void Validator_ShouldReturnErrors_WhenCommandIsInvalid(SendEmailCommand command)
    {
        // Assign
        var validationContext = new ValidationContext<SendEmailCommand>(command);

        // Act
        var result = _validator.Validate(validationContext);

        // Assert
        result.IsValid
            .Should()
            .BeFalse();
    }
    
    [Theory]
    [ClassData(typeof(SendEmailValidCommands))]
    public void Validator_ShouldReturnOkResult_WhenCommandIsValid(SendEmailCommand command)
    {
        // Assign
        var validationContext = new ValidationContext<SendEmailCommand>(command);

        // Act
        var result = _validator.Validate(validationContext);

        // Assert
        result.IsValid
            .Should()
            .BeTrue();
    }
}