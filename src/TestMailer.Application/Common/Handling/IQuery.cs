using ErrorOr;
using MediatR;

namespace TestMailer.Application.Common.Handling;

/// <summary>
/// Запрос, не мутирующий состояние системы и возвращающий данные
/// </summary>
/// <typeparam name="TResponse">Тип возвращаемых данных</typeparam>
public interface IQuery<TResponse> : IRequest<ErrorOr<TResponse>>
{
    
}