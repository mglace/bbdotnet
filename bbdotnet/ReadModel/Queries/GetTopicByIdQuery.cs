using System;
using CQRSlite.Queries;

namespace bbdotnet
{
    public class GetTopicByIdQuery : IQuery<TopicListItemDTO>
    {
        public Guid Id { get; }

        public GetTopicByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}