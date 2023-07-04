using System.Net;

namespace TestMailer.Api.Endpoints;

/// <summary>
/// Базовый класс описания эндпоинта для сваггера
/// </summary>
public abstract class EndpointSummaryBase : EndpointSummary
{
    /// <summary>
    /// Добавление примера ответа при успешном выполении
    /// </summary>
    /// <param name="statusCode">Код ответа</param>
    /// <param name="response">Возвращаемые полезные данные</param>
    /// <typeparam name="TResponse">Тип полезных данных</typeparam>
    protected void AddSuccessResponseExample<TResponse>(HttpStatusCode statusCode, TResponse response)
    {
        ResponseExamples[(int)statusCode] = new ApiResponse<TResponse>(response, false, new());
    }
    
    /// <summary>
    /// Добавление примера ответа при неудачном выполении
    /// </summary>
    /// <param name="statusCodes">Список кодов, в которых может быть ошибка</param>
    protected void AddFailResponseExamples(params HttpStatusCode[] statusCodes)
    {
        foreach (var code in statusCodes)
        {
            ResponseExamples[(int)code] = new ApiResponse<object>(
                null, true, new() { "Error1", "Error2", "..." });
        }
    }
}