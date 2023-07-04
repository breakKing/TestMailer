using System.Transactions;

namespace TestMailer.Application.Common.DataAccess;

/// <summary>
/// Unit-of-work для управления транзакциями;
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Создание области транзакции
    /// </summary>
    /// <returns>Disposable-объект области транзакции</returns>
    TransactionScope CreateTransactionScope();
}