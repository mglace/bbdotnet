using bbdotnet.Application.Abstractions;
using bbdotnet.Domain.Shared;

namespace bbdotnet.Application.Behaviors.Validation;

public sealed class ValidationResult : Result, IValidationResult
{
    private ValidationResult(Error[] errors)
        : base(false, IValidationResult.ValidationError) =>
        Errors = errors;

    public Error[] Errors { get; }

    public static ValidationResult WithErrors(Error[] errors) => new(errors);
}
