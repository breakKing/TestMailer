﻿using OneOf;

namespace TestMailer.Application.Common.Handling;

/// <summary>
/// Кастомный класс результата выполнения запросов и команд
/// </summary>
/// <typeparam name="TData">Тип данных, возвращаемых в случае успеха выполнения запросов и команд</typeparam>
public class Result<TData>: OneOfBase<TData, Error[]>
{
    /// <summary>
    /// Результат является удачным
    /// </summary>
    public bool IsSucceeded => IsT0;
    
    /// <summary>
    /// Результат является ошибкой
    /// </summary>
    public bool IsError => IsT1;
    
    /// <inheritdoc />
    public Result(OneOf<TData, Error[]> input) : base(input)
    {
    }

    /// <summary>
    /// Создание результата в случае успеха
    /// </summary>
    /// <param name="data">Данные, которые необходимо записать в результат</param>
    /// <returns></returns>
    public static Result<TData> Success(TData data) => new(data);

    /// <summary>
    /// Создание результата в случае ошибки
    /// </summary>
    /// <param name="errors">Описание возникших ошибок</param>
    /// <returns></returns>
    public static Result<TData> Failure(params Error[] errors) => new(errors);
}