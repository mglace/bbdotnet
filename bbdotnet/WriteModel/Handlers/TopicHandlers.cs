using System.Threading;
using System.Threading.Tasks;
using CQRSlite.Commands;
using CQRSlite.Domain;

namespace bbdotnet
{
    public class TopicHandlers : ICommandHandler<CreateTopicCommand>,
        ICancellableCommandHandler<ReplyToTopicCommand>
    {
        private readonly ISession _session;

        public TopicHandlers(ISession session)
        {
            _session = session;
        }

        public async Task Handle(CreateTopicCommand message)
        {
            var newTopicId = 1; // Go to the database to get a new ID

            var topic = new Topic(message.AggregateId, newTopicId, message.Title);

            await _session.Add(topic);
            await _session.Commit();
        }
        
        public async Task Handle(ReplyToTopicCommand message, CancellationToken token = new CancellationToken())
        {
            var topic = await _session.Get<Topic>(message.AggregateId, message.ExpectedVersion, token);
            
            topic.Reply(message.AggregateId, message.Content, message.Timestamp);

            await _session.Commit(token);
        }
    }
}