# TestMailer

## Краткое описание

Тестовое задание по созданию WebApi с двумя эндпоинтами:

- для отправки письма и записи результата отправки в БД;
- для получения всех записей об отправках из БД.

## Архитектура и используемые технологии

Проект реализован на **.NET 7** с использованием чистой архитектуры.

На уровне **Api** вместо паттерна _MVC_ и контроллеров используется паттерн _REPR_ (_Request-Endpoint-Response_) и библиотека [FastEndpoints](https://fast-endpoints.com/), являющаяся более практичным и производительным аналогом minimal apis.

На уровне **Infrastructure** для хранения данных используется ORM [Entity Framework Core](https://github.com/dotnet/efcore#entity-framework-core) и СУБД _PostgreSQL_. Для отправки электронных писем используется библиотека [MailKit](https://github.com/jstedfast/MailKit).

На уровне **Application** используется [MediatR](https://github.com/jbogard/MediatR) для выполнения запросов и команд, а также библиотека [FluentValidation](https://docs.fluentvalidation.net/en/latest/) для их валидации.

На уровне **Domain** единственная сущность реализована с соблюдением основных принципов _DDD_ (_Domain-Driven Design_).

Для юнит-тестов команды отправки письма был использован фреймворк **XUnit** в связке с библиотекой [FluentAssertions](https://fluentassertions.com/).