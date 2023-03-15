using bbdotnet.Domain;
using Mapster;

namespace bbdotnet.Application.Topics.Models;
internal class Mappers : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Topic, TopicDetailDTO>()
            .Map(dst => dst.Id, src => src.Id.Value);
    }
}
