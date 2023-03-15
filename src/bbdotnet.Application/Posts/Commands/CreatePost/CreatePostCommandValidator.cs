using bbdotnet.Domain;
using FluentValidation;

namespace bbdotnet.Application.Posts.Commands;

internal sealed class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        // TODO: Check for quote depth
        // TODO: Check non-ascii chars
        RuleFor(x => x.Body)
            .NotEmpty()
            .MaximumLength(Post.MaxBodyLength);
    }
}
