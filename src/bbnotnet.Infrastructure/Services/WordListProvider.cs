using bbdotnet.Application.Abstractions.Interfaces;

namespace bbdotnet.Infrastructure.Services;

internal class StaticWordListProvider : IWordListProvider
{
    public IEnumerable<string> Words => new string[] { /* Add profanities here */ };
}

internal class FileWordListProvider : IWordListProvider
{
    public IEnumerable<string> Words => throw new NotImplementedException();
}