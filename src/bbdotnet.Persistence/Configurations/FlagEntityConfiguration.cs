using bbdotnet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bbdotnet.Persistence.Configurations;

internal class FlagEntityConfiguration : IEntityTypeConfiguration<Flag>
{
    public void Configure(EntityTypeBuilder<Flag> builder)
    {
        builder.ToTable("Flag");

        builder.Property(f => f.FlaggedBy)
            .HasConversion(
                id => id.Value,
                value => MemberId.Create(value));

        builder.HasDiscriminator<char>("Type")
            .HasValue<TopicFlag>('t')
            .HasValue<PostFlag>('p');
    }
}

//internal class TopicFlagEntityConfiguration : IEntityTypeConfiguration<TopicFlag>
//{
//    public void Configure(EntityTypeBuilder<TopicFlag> builder)
//    {
//    }
//}

//internal class PostFlagEntityConfiguration : IEntityTypeConfiguration<PostFlag>
//{
//    public void Configure(EntityTypeBuilder<PostFlag> builder)
//    {
//    }
//}
