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
        }
    }
}
