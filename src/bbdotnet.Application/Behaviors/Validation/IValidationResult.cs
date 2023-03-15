using bbdotnet.Domain.Shared;

namespace bbdotnet.Application.Behaviors.Validation;

public interface IValidationResult
{
    public static readonly Error ValidationError = new(
        "ValidationError",
        "A validation problem occurred.");

    Error[] Errors { get; }
}
