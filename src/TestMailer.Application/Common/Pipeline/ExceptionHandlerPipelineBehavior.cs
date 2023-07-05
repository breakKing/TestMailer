using MediatR;
using Microsoft.Extensions.Logging;
using TestMailer.Application.Common.Handling;

namespace TestMailer.Application.Common.Pipeline;

/// <summary>
/// Поведение пайплайна для отлова неожиданных исключений
/// </summary>
/// <typeparam name="TRequest">Тип запроса/команды</typeparam>
/// <typeparam name="TResponse">Тип ответа</typeparam>
internal sealed class ExceptionHandlerPipelineBehavior<TRequest, TResponse> : 
    IPipelineBehavior<TRequest, Result<TResponse>> 
    where TRequest : notnull
{
    private const string UnhandledExceptionErrorCode = "Exception";
    
    private readonly ILogger<ExceptionHandlerPipelineBehavior<TRequest, TResponse>> _logger;

    public ExceptionHandlerPipelineBehavior(ILogger<ExceptionHandlerPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<Result<TResponse>> Handle(
        TRequest request, 
        RequestHandlerDelegate<Result<TResponse>> next, 
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            _logger.LogError("An exception was caught: {@Exception}", ex);

            var error = new Error(UnhandledExceptionErrorCode, ex.Message);
            return Result<TResponse>.Failure(error);
        }
    }
}