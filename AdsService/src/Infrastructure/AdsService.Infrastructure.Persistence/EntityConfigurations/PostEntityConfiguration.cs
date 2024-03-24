using AdsService.Application.Models.Entities;
using AdsService.Application.Models.ValueObjects;
using AdsService.Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsService.Infrastructure.Persistence.EntityConfigurations;

public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Content).HasConversion<PostContentConverter>().HasMaxLength(PostContent.MaxLength);

        builder.HasOne<User>(e => e.User).WithMany().IsRequired();
    }
}