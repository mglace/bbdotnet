using bbdotnet.Domain;
using FluentValidation;

namespace bbdotnet.Application.Posts.Commands;

internal sealed class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        // TODO: Check for quote depth
        RuleFor(x => x.Body)
            .NotEmpty()
            .MaximumLength(Post.MaxBodyLength)
            .Must(t => t.ContainsOnlyPrintableChars());
    }
}
