using bbdotnet.Application.Abstractions.Interfaces;

namespace bbdotnet.Infrastructure.Services;

internal class StaticWordListProvider : IWordListProvider
{
    public IEnumerable<string> Words => new string[] { "fuck" };
}
