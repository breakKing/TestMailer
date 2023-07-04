namespace TestMailer.Api.Endpoints;

/// <summary>
/// Базовый ответ для всех эндпоинтов
/// </summary>
/// <param name="Data">Полезные данные (при их наличии)</param>
/// <param name="Failed">Флаг о том, завершился ли запрос с ошибкой</param>
/// <param name="Errors">Список ошибок</param>
/// <typeparam name="TData">Тип полезных данных</typeparam>
public record ApiResponse<TData>(TData? Data, bool Failed, List<string> Errors);