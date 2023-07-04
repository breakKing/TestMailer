namespace TestMailer.Domain.Mailing;

public sealed class Email
{
    private readonly List<string> _recipients = new();
    
    /// <summary>
    /// Идентификатор письма
    /// </summary>
    public Guid Id { get; private set; }
    
    /// <summary>
    /// Тема письма
    /// </summary>
    public string Subject { get; private set; }
    
    /// <summary>
    /// Тело письма
    /// </summary>
    public string Body { get; private set; }

    /// <summary>
    /// Получатели
    /// </summary>
    /// <returns></returns>
    public IReadOnlyList<string> Recipients => _recipients;
    
    /// <summary>
    /// Дата создания письма
    /// </summary>
    public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// Результат отправки
    /// </summary>
    public EmailResult Result { get; private set; } = EmailResult.Processing;
    
    /// <summary>
    /// Информация об ошибке отправки (если есть)
    /// </summary>
    public string? FailedMessage { get; private set; }

    private Email()
    {
        Subject = string.Empty;
        Body = string.Empty;
    }

    /// <summary>
    /// Конструктор для письма
    /// </summary>
    /// <param name="subject">Тема</param>
    /// <param name="body">Тело</param>
    /// <param name="recipients">Получатели</param>
    public Email(string subject, string body, ICollection<string> recipients)
    {
        Id = Guid.NewGuid();
        Subject = subject;
        Body = body;

        _recipients.AddRange(recipients);
    }

    /// <summary>
    /// Пометить письмо как удачно отправленное
    /// </summary>
    public void MarkAsSent()
    {
        Result = EmailResult.Ok;
    }

    /// <summary>
    /// Пометить письмо как неотправленное (с ошибкой)
    /// </summary>
    /// <param name="failedMessage"></param>
    public void MarkAsFailed(string failedMessage)
    {
        Result = EmailResult.Failed;
        FailedMessage = failedMessage;
    }
}