using bbdotnet.Application.Common;
using ErrorOr;

namespace bbdotnet.Application.Topics.Commands
{
    public record DeleteTopicCommand(int Id) : ICommand<bool>;

    public class DeleteTopicCommandHandler : ICommandHandler<DeleteTopicCommand, bool>
    {
        public Task<ErrorOr<bool>> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
