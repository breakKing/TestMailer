using FluentValidation;
using MediatR;
using TestMailer.Application.Common.Handling;

namespace TestMailer.Application.Common.Pipeline;

/// <summary>
/// Поведение пайплайна для проведения валидации запросов и команд
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
internal sealed class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, Result<TResponse>> 
    where TRequest : notnull
{
    private const string ValidationErrorCode = "Validation";
    
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    /// <inheritdoc />
    public async Task<Result<TResponse>> Handle(
        TRequest request, 
        RequestHandlerDelegate<Result<TResponse>> next, 
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }
        
        var context = new ValidationContext<TRequest>(request);
        
        var errorsDictionary = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .GroupBy(
                x => x.PropertyName,
                x => x.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                })
            .ToDictionary(x => x.Key, x => x.Values);
        
        if (errorsDictionary.Count > 0)
        {
            var errors = errorsDictionary
                .SelectMany(e => e.Value)
                .Select(e => new Error(ValidationErrorCode, e))
                .ToArray();
            
            return Result<TResponse>.Failure(errors);
        }
        
        return await next();
    }
}