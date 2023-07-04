using MediatR;

namespace TestMailer.Application.Common.Handling;

/// <summary>
/// Обработчик запроса на получение данных
/// </summary>
/// <typeparam name="TQuery">Тип запроса</typeparam>
/// <typeparam name="TResponse">Тип возвращаемых данных</typeparam>
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
    
}