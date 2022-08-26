using bbdotnet.Application.Posts.Commands;
using Mapster;

namespace bbdotnet.WebApi.Models
{
    public class RequestToCommandMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(int TopicId, ReplyToTopicRequest Request), ReplyToTopicCommand>()
                .Map(d => d.TopicId, s => s.TopicId)
                .Map(d => d, s => s.Request);
        }
    }
}
