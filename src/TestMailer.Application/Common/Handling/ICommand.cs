using ErrorOr;
using MediatR;

namespace TestMailer.Application.Common.Handling;

/// <summary>
/// Команда, мутирующая состояние системы
/// </summary>
public interface ICommand : IRequest<ErrorOr<bool>>
{
    
}