using bbdotnet.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bbdotnet.Persistence.Configurations
{
    internal class PostEntityConfiguration : IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.ToTable("Post");

            builder.HasOne(p => p.Topic)
                .WithMany(t => t.Replies)
                .HasForeignKey(p => p.TopicId);
        }
    }
}
