using System.Text.RegularExpressions;

namespace bbdotnet.Application;

public static class Settings
{
    public static readonly int DefaultPageSize = 50;

    public static readonly int MaxPageSize = 100;

    public static readonly int MaxNestedQuoteDepth = 4;
}
