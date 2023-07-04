namespace TestMailer.Application.Common.Pagination;

public sealed record PaginationInfoDto(int PageNumber, int PageSize, long TotalItems)
{
    public int TotalPages => (int)((TotalItems - 1) / PageSize + 1);
    public bool HasNext => PageNumber < TotalPages;
    public bool HasPrevious => PageNumber > 1;
};