using MediatR;

namespace TestMailer.Application.Common.Handling;

/// <summary>
/// Обработчик команды
/// </summary>
/// <typeparam name="TCommand">Тип обрабатываемой команды</typeparam>
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result<bool>>
    where TCommand : ICommand
{
    
}