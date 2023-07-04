namespace TestMailer.Domain.Mailing;

/// <summary>
/// Возможные результаты отправки письма
/// </summary>
public enum EmailResult
{
    /// <summary>
    /// В обработке
    /// </summary>
    Processing = 0,
    Ok = 1,
    Failed = 2
}