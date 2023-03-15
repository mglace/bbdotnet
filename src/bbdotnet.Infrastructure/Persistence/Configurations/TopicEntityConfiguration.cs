using bbdotnet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bbdotnet.Infrastructure.Persistence.Configurations;

internal class TopicEntityConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.ToTable("Topic");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => TopicId.Create(value));

        builder.Property(t => t.Title)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.RemovedBy)
            .HasConversion(
                id => id == null ? default : id.Value,
                value => MemberId.Create(value));

        builder.OwnsMany(m => m.TagIds, tid =>
        {
            tid.ToTable("TopicTagId");

            tid.Property(d => d.Value)
                .HasColumnName("TagId")
                .ValueGeneratedNever();

            tid.WithOwner().HasForeignKey("TopicId");

            tid.HasKey("TopicId", "Value");

            tid.HasOne<Tag>()
                .WithMany()
                .HasForeignKey(t => t.Value);
        });

        builder.Property<byte[]>("RowVersion")
            .IsRowVersion();
    }
}
