using bbdotnet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bbdotnet.Persistence.Configurations;

internal class PostEntityConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Post");

        builder.HasKey(p  => p.Id);

        builder.Property(p => p.Body)
            .HasMaxLength(3000)
            .IsRequired();

        builder.Property(t => t.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PostId.Create(value));

        builder.Property(x => x.TopicId)
            .HasConversion(
                id => id.Value,
                value => TopicId.Create(value));

        builder.Property(t => t.AuthorId)
            .HasConversion(
                id => id.Value,
                value => MemberId.Create(value));

        builder.Property(t => t.RemovedBy)
            .HasConversion(
                id => id == null ? default : id.Value,
                value => MemberId.Create(value));
    }
}
