using System.Net;

namespace TestMailer.Api.Endpoints.Mail.Get;

/// <summary>
/// Описание эндпоинта получения писем
/// </summary>
public sealed class GetEmailsEndpointSummary : EndpointSummaryBase
{
    private static readonly GetEmailsApiResponse SuccessResponseExample =
        new GetEmailsApiResponse(
            new List<EmailItemApiDto>
            {
                new EmailItemApiDto(
                    "Приветствие", 
                    "Привет, мир!", 
                    new List<string>
                    {
                        "test1@example.com", 
                        "test2@example.com"
                    },
                    DateTimeOffset.UtcNow,
                    "Ok",
                    null),
                new EmailItemApiDto(
                    "Приветствие 2", 
                    "Привет, мир 2!", 
                    new List<string>
                    {
                        "test1@example.com", 
                        "test2@example.com"
                    },
                    DateTimeOffset.UtcNow,
                    "Failed",
                    "Описание ошибки")
            });
    
    public GetEmailsEndpointSummary()
    {
        Summary = "Выгрузка списка писем";
        Description = "Выгрузка списка всех писем с информацией об их статусах отправки";
        
        AddSuccessResponseExample(HttpStatusCode.OK, SuccessResponseExample);
        AddFailResponseExamples(HttpStatusCode.InternalServerError);
    }
}