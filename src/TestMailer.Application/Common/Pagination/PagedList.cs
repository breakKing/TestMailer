namespace TestMailer.Application.Common.Pagination;

public record PagedList<T>(List<T> Items, PaginationInfoDto PaginationInfo);