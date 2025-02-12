using Microsoft.EntityFrameworkCore;
using Shop.Shared.Core.Pagination;

namespace Shop.Server.DAL.Core;

public static class PagedListExtensions
{
    public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, PagingQuery query)
    {
        var totalItems = source.Count();

        if (totalItems < 1) return PagedList<T>.CreateSinglePage([]);

        var items = await source
            .Skip(query.Offset())
            .Take(query.PageSize)
            .ToListAsync();

        return PagedList<T>.CreateMultiplePages(items, query, totalItems);
    }

    public static PagedList<T> AsPagedList<T>(this IEnumerable<T> source, PagingMetadata metadata)
    {
        return new PagedList<T>
        {
            Items = source.ToList(),
            Metadata = metadata
        };
    }
}