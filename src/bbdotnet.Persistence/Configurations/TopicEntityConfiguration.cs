using bbdotnet.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bbdotnet.Persistence.Configurations
{
    internal class TopicEntityConfiguration : IEntityTypeConfiguration<TopicEntity>
    {
        public void Configure(EntityTypeBuilder<TopicEntity> builder)
        {
            builder.ToTable("Topic");

            builder.Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasMany(p => p.Tags)
                .WithMany(t => t.Topics)
                .UsingEntity(j => j.ToTable("TopicTags"));

            builder.Property(x => x.Timestamp)
                .HasColumnName("Timestamp")
                .HasColumnType("timestamp")
                .IsRowVersion();
        }
    }
}
