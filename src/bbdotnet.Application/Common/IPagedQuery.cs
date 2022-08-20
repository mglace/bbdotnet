using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace bbdotnet.Application.Common
{
    internal interface IPagedQuery<TResponse> : IQuery<PagedList<TResponse>>
    {
        int PageNumber { get; }

        int PageSize { get; }
    }

    public abstract record PagedQuery<TResponse> : IPagedQuery<TResponse>
    {
        public int PageNumber { get; init; }

        public int PageSize { get; init; }
    }

    internal interface IPagedQueryHandler<TPagedQuery, TPagedResponse> : IQueryHandler<TPagedQuery, PagedList<TPagedResponse>>
        where TPagedQuery : IPagedQuery<TPagedResponse>
    { 
    }

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

    public class PagedList<T> : IReadOnlyCollection<T>
    {
        private readonly IEnumerable<T> _items;

        internal PagedList(IEnumerable<T> items, int totalCount, bool hasPreviousPage, bool hasNextPage)
        {
            _items = items;

            TotalCount = totalCount;
            HasPreviousPage = hasPreviousPage;
            HasNextPage = hasNextPage;
        }

        public bool HasPreviousPage { get; }

        public bool HasNextPage { get; }

        public int TotalCount { get; }

        public int Count => _items.Count();

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
