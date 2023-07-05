using System.Net;

namespace TestMailer.Api.Endpoints.Mail.Send;

/// <summary>
/// Описание эндпоинта для отправки писем
/// </summary>
public sealed class SendEmailEndpointSummary : EndpointSummaryBase
{
    public SendEmailEndpointSummary()
    {
        Summary = "Отправка письма";
        Description = "Отправка электронного письма по заранее подготовленной конфигурации";
        
        AddSuccessResponseExample(HttpStatusCode.OK, new SendEmailApiResponse());
        AddFailResponseExamples(HttpStatusCode.InternalServerError);
    }
}