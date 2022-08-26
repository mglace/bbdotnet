using bbdotnet.Application.Topics.Commands;
using Mapster;

namespace bbdotnet.WebApi.Models
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<CreateTopicRequest, CreateTopicCommand>();
        }
    }
}
