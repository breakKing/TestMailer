namespace TestMailer.Application.Common.Pagination;

/// <summary>
/// Базовый запрос пагинации
/// </summary>
/// <param name="PageNumber">Номер страницы</param>
/// <param name="PageSize">Размер страницы</param>
public sealed record PaginationRequest(int PageNumber, int PageSize)
{
    public int SkipCount => (PageNumber - 1) * PageSize;
};