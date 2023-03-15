namespace bbdotnet.Application.Abstractions.Interfaces;

public interface IWordListProvider
{
    IEnumerable<string> Words { get; }
}
