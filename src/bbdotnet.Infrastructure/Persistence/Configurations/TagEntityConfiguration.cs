using bbdotnet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bbdotnet.Infrastructure.Persistence.Configurations;

internal class TagEntityConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tag");

        builder.Property(p => p.Name).HasMaxLength(50);
    }
}
