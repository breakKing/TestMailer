﻿using System.Net;
using ErrorOr;

namespace TestMailer.Api.Endpoints;

/// <summary>
/// Базовый класс эндпоинта
/// </summary>
/// <typeparam name="TRequest">Тип запроса</typeparam>
/// <typeparam name="TResponse">Тип ответа</typeparam>
public abstract class EndpointBase<TRequest, TResponse> : Endpoint<TRequest, ApiResponse<TResponse>>
    where TRequest : notnull
{
    /// <summary>
    /// Отправка ответа при успешном выполнении запроса
    /// </summary>
    /// <param name="response">Полезные данные</param>
    /// <param name="statusCode">Код ответа (по умолчанию 200)</param>
    /// <param name="ct">Токен отмены</param>
    protected async Task SendDataAsync(
        TResponse response, 
        HttpStatusCode statusCode = HttpStatusCode.OK,
        CancellationToken ct = default)
    {
        var apiResponse = new ApiResponse<TResponse>(response, false, new());
        await SendAsync(apiResponse, (int)statusCode, cancellation: ct);
    }

    /// <summary>
    /// Отправка ответа при неудачном выполнении запроса
    /// </summary>
    /// <param name="errors">Список ошибок</param>
    /// <param name="statusCode">Код ответа (по умолчанию 400)</param>
    /// <param name="ct">Токен отмены</param>
    protected async Task SendErrorsAsync(
        List<string> errors, 
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        CancellationToken ct = default)
    {
        var apiResponse = new ApiResponse<TResponse>(default, true, errors);
        await SendAsync(apiResponse, (int)statusCode, ct);
    }

    /// <summary>
    /// Отправка ответа при неудачном выполнении запроса
    /// </summary>
    /// <param name="error">Ошибка</param>
    /// <param name="statusCode">Код ответа (по умолчанию 400)</param>
    /// <param name="ct">Токен отмены</param>
    protected async Task SendErrorsAsync(
        string error, 
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        CancellationToken ct = default)
    {
        await SendErrorsAsync(new List<string> { error }, statusCode, ct);
    }

    /// <summary>
    /// Отправка ответа на основе результата, полученного с уровня приложения (от запроса/команды)
    /// </summary>
    /// <param name="result">Ответ на запрос/команду</param>
    /// <param name="apiResponseBuilder">
    /// Функция для построения ответа от api при успешном выполнении запроса/команды
    /// </param>
    /// <param name="ct">Токен отмены</param>
    /// <typeparam name="TResult">Тип запроса/команды</typeparam>
    protected async Task SendResponseAsync<TResult>(
        ErrorOr<TResult> result, 
        Func<TResult, TResponse> apiResponseBuilder,
        CancellationToken ct = default)
    {
        var task = result.Match(
            data => SendDataAsync(apiResponseBuilder.Invoke(data), ct: ct),
            errors => SendErrorsAsync(
                errors.Select(e => e.Description).ToList(),
                HttpStatusCode.BadRequest,
                ct));

        await task;
    }

    /// <summary>
    /// Конфигурация описания эндпоинта в сваггере
    /// </summary>
    /// <param name="summary">Основное описание эндпоинта</param>
    /// <param name="statusCodes">Возможные коды ответа от эндпоинта</param>
    protected virtual void ConfigureSwaggerDescription(
        EndpointSummaryBase summary, 
        params HttpStatusCode[] statusCodes)
    {
        DontAutoTag();
        
        Description(desc =>
        {
            foreach (var code in statusCodes)
            {
                desc.Produces<ApiResponse<TResponse>>((int)code);
            }
        });
        
        Summary(summary);
    }
}

public abstract class EndpointWithoutRequestBase<TResponse> : EndpointBase<EmptyRequest, TResponse>
{

}