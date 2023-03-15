using bbdotnet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bbdotnet.Infrastructure.Persistence.Configurations;

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
