using FluentValidation;

namespace TestMailer.Application.Mailing.SendEmail;

/// <summary>
/// Валидатор для команды на отправку письма
/// </summary>
internal sealed class SendEmailCommandValidator : AbstractValidator<SendEmailCommand>
{
    private const int SubjectMaxLength = 120;

    public SendEmailCommandValidator()
    {
        RulesForSubject();
        RulesForBody();
        RulesForRecipients();
    }

    private void RulesForRecipients()
    {
        RuleFor(c => c.Recipients)
            .NotEmpty()
            .WithMessage("Для письма не указан ни один получатель");

        RuleForEach(c => c.Recipients)
            .EmailAddress()
            .WithMessage("Один или несколько получателей не являются валидными адресами почтовых ящиков");
    }

    private void RulesForBody()
    {
        RuleFor(c => c.Body)
            .NotEmpty()
            .WithMessage("Тело письма не должно быть пустым");
    }

    private void RulesForSubject()
    {
        RuleFor(c => c.Subject)
            .NotEmpty()
            .WithMessage("Тема письма должна быть заполнена");

        RuleFor(c => c.Subject)
            .MaximumLength(SubjectMaxLength)
            .WithMessage($"Тема письма должна иметь не более {SubjectMaxLength} символов");
    }
}