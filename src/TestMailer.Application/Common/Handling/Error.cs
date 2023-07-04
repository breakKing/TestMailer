namespace TestMailer.Application.Common.Handling;

/// <summary>
/// Кастомный класс ошибки во время выполнения запросов
/// </summary>
/// <param name="Code">Код ошибки</param>
/// <param name="Description">Человеко-читаемое описание ошибки</param>
public sealed record Error(string Code, string Description);