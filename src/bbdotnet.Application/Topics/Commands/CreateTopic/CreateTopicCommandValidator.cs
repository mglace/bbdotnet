using bbdotnet.Application.Abstractions.Interfaces;
using bbdotnet.Domain;
using FluentValidation;

namespace bbdotnet.Application.Topics.Commands;

internal sealed class CreateTopicCommandValidator : AbstractValidator<CreateTopicCommand>
{
    public CreateTopicCommandValidator(IProfanityService profanityService)
    {
        // TODO: Check for profanity
        // TODO: Check non-ascii chars
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(Topic.MaxTitleLength)
            .Must(t => t.ContainsOnlyPrintableChars())
            .Must(t => !profanityService.ContainFilth(t))
                .WithMessage("Watch your filthly mouth");

        // TODO: Check for quote depth
        // TODO: Check non-ascii chars
        RuleFor(x => x.Body)
            .NotEmpty()
            .MaximumLength(Post.MaxBodyLength)
            .Must(t => t.ContainsOnlyPrintableChars());
    }
}
