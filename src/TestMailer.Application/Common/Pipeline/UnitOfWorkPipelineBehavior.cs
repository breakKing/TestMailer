using System.Transactions;
using MediatR;
using TestMailer.Application.Common.DataAccess;
using TestMailer.Application.Common.Handling;

namespace TestMailer.Application.Common.Pipeline;

/// <summary>
/// Поведение пайплайна для обёртки каждой команды в транзакцию
/// </summary>
/// <typeparam name="TCommand">Тип команды</typeparam>
/// <typeparam name="TResponse">Тип ответа</typeparam>
internal sealed class UnitOfWorkPipelineBehavior<TCommand, TResponse> : IPipelineBehavior<TCommand, TResponse>
    where TCommand : ICommand
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkPipelineBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc />
    public async Task<TResponse> Handle(
        TCommand request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            var result = await next();
        
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            transactionScope.Complete();

            return result;
        }
    }
}