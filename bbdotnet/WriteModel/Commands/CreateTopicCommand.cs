using System;

namespace bbdotnet
{
    public class CreateTopicCommand : BaseCommand
    {
        public CreateTopicCommand(Guid aggregateId, string title, string content)
        : base(aggregateId)
        {
            Title = title;
            Content = content;
        }

        public string Title { get; }

        public string Content { get; }
    }
}