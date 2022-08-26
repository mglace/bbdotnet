namespace bbdotnet.Application.Services
{
    public interface IApplicationContext
    {
        int UserId { get; }

        bool TryGetUserId(out int id);
    }
}
