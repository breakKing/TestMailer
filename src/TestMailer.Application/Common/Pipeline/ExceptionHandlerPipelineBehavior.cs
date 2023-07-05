using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace TestMailer.Application.Common.Pipeline;

/// <summary>
/// Поведение пайплайна для отлова неожиданных исключений
/// </summary>
/// <typeparam name="TRequest">Тип запроса/команды</typeparam>
/// <typeparam name="TResponse">Тип ответа</typeparam>
internal sealed class ExceptionHandlerPipelineBehavior<TRequest, TResponse> : 
    IPipelineBehavior<TRequest, TResponse> 
    where TRequest : notnull
    where TResponse : IErrorOr, new()
{
    private const string UnhandledExceptionErrorCode = "Exception";
    
    private readonly ILogger<ExceptionHandlerPipelineBehavior<TRequest, TResponse>> _logger;

    public ExceptionHandlerPipelineBehavior(ILogger<ExceptionHandlerPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            _logger.LogError("An exception was caught: {@Exception}", ex);

            var error = Error.Unexpected(UnhandledExceptionErrorCode, ex.Message);

            var response = new TResponse();
            response.Errors!.Add(error);
            
            return response;
        }
    }
}