namespace bbdotnet;

public static class CollectionExtensions
{
    public static IReadOnlyCollection<T> AsReadOnlyOrEmpty<T>(this List<T>? list) =>
        list != null ? list.AsReadOnly() : Array.Empty<T>();
}
