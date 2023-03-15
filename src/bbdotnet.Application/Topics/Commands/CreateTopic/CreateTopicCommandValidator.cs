using bbdotnet.Application.Abstractions.Interfaces;
using bbdotnet.Domain;
using FluentValidation;

namespace bbdotnet.Application.Topics.Commands;

internal sealed class CreateTopicCommandValidator : AbstractValidator<CreateTopicCommand>
{
    public CreateTopicCommandValidator(IProfanityService profanityService)
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(Topic.MaxTitleLength)
            .Must(t => t.ContainsOnlyPrintableChars())
            .Must(t => !profanityService.ContainFilth(t))
                .WithMessage("Topic title must not contain profanity");

        // TODO: Check for quote depth
        RuleFor(x => x.Body)
            .NotEmpty()
            .MaximumLength(Post.MaxBodyLength)
            .Must(t => t.ContainsOnlyPrintableChars());
    }
}
