namespace TestMailer.Application.Common.DataAccess;

/// <summary>
/// Unit-of-work для управления сохранением и транзакциями
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Сохранение изменений
    /// </summary>
    /// <param name="ct">Токен отмены</param>
    /// <returns>Кол-во строк, затронутых в БД при выполнении операции</returns>
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}