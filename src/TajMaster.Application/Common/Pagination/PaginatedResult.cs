namespace TajMaster.Application.Common.Pagination;

public class PaginatedResult<T>(int pageNumber, int pageSize, int totalPages, IEnumerable<T> items)
{
    public int PageNumber { get; } = pageNumber;
    public int PageSize { get; } = pageSize;
    public int TotalPages { get; } = totalPages;
    public IEnumerable<T> Items { get; } = items;
}