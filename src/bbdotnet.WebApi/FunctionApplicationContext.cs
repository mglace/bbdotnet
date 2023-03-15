using bbdotnet.Application.Abstractions.Interfaces;

namespace bbdotnet.WebApi;

internal class FunctionApplicationContext : IApplicationContext
{
    public Guid UserId => throw new NotImplementedException();

    public bool TryGetUserId(out Guid id)
    {
        throw new NotImplementedException();
    }
}