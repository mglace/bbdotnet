using bbdotnet.Application.Abstractions.Interfaces;
using System.Text.RegularExpressions;

namespace bbdotnet.Infrastructure.Services;

public class ProfanityService : IProfanityService
{
    private static readonly char[] _separators = {' ', '_', '*', '-'};

    private readonly string[] _regexPatterns;

    public ProfanityService(IWordListProvider wordListProvider)
    {
        _regexPatterns = wordListProvider.Words.Select(w => $"^{w}$").ToArray();
    }

    public bool ContainFilth(string text)
    {
        ArgumentException.ThrowIfNullOrEmpty(text);

        text = text.ToLowerInvariant();

        var words = text.Split(_separators, StringSplitOptions.RemoveEmptyEntries);

        var len = _regexPatterns.Length;

        for (var x = 0; x < words.Length; x++)
        {
            var normalized = words[x].NormalizeString();

            for (var y = 0; y < len; y++)
            {
                if (Regex.IsMatch(normalized, _regexPatterns[y])) return true;
            }
        }

        return false;
    }
}
