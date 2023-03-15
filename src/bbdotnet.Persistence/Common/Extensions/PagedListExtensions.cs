using bbdotnet.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace bbdotnet.Persistence.Common.Extensions;

internal static class PagedList
{
    public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        var totalCount = await query.CountAsync(cancellationToken);

        var skip = pageSize * (pageNumber - 1);

        var items = await query
            .Skip(skip)
            .Take(pageSize + 1)
            .ToListAsync(cancellationToken);

        var hasPreviousPage = pageNumber > 1;
        var hasNextPage = items.Count > pageSize;

        return new PagedList<T>(items.Take(pageSize), totalCount, hasPreviousPage, hasNextPage);
    }
}
