using System.Collections;

namespace bbdotnet.Application.Abstractions;

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

public interface IPagedList<T> : IReadOnlyCollection<T>
{
}

public class PagedList<T> : IReadOnlyCollection<T>
{
    private readonly IEnumerable<T> _items;

    public PagedList(IEnumerable<T> items, int totalCount, bool hasPreviousPage, bool hasNextPage)
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
