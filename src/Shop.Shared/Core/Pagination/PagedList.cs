namespace Shop.Shared.Core.Pagination;

public sealed class PagedList<T>
{
    public List<T> Items { get; set; } = [];

    public PagingMetadata Metadata { get; set; } = new();

    public static PagedList<T> CreateMultiplePages(IList<T> items, PagingQuery query, int totalItems)
    {
        return new PagedList<T>
        {
            Items = items.ToList(),
            Metadata = new PagingMetadata
            {
                PageNumber = query.PageNumber,
                PageSize = query.PageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling(totalItems / (double)query.PageSize)
            }
        };
    }

    public static PagedList<T> CreateSinglePage(IList<T> items)
    {
        var count = items.Count;

        return new PagedList<T>
        {
            Items = items.ToList(),
            Metadata = new PagingMetadata
            {
                PageNumber = 1,
                PageSize = count,
                TotalItems = count,
                TotalPages = 1
            }
        };
    }
}