using System;
using System.Threading.Tasks;
using CQRSlite.Events;
using CQRSlite.Queries;

namespace bbdotnet
{
    public class TopicListingEventHandlers : IEventHandler<TopicCreatedEvent>,
        IEventHandler<TopicRepliedToEvent>,
        IQueryHandler<GetTopicByIdQuery, TopicListItemDTO>
    {
        public Task Handle(TopicCreatedEvent message)
        {
            InMemoryDatabase.ListItems.Add(message.Id,
                new TopicListItemDTO
                {
                    Id = message.TopicId,
                    Title = message.Title,
                    AggregateId = message.Id,
                    Version = message.Version
                });

            return Task.CompletedTask;
        }

        public Task<TopicListItemDTO> Handle(GetTopicByIdQuery query)
        {
            return Task.FromResult(InMemoryDatabase.ListItems[query.Id]);
        }

        public Task Handle(TopicRepliedToEvent message)
        {
            var topic = GetListingItem(message.Id);

            topic.PostCount = message.PostCount;
            topic.LastPostDate = message.Timestamp;
            topic.Version = message.Version;

            return Task.CompletedTask;
        }

        private static TopicListItemDTO GetListingItem(Guid id)
        {
            if (!InMemoryDatabase.ListItems.TryGetValue(id, out var dto))
            {
                throw new InvalidOperationException("Did not find the original topic, this shouldn't happen");
            }

            return dto;
        }
    }
}