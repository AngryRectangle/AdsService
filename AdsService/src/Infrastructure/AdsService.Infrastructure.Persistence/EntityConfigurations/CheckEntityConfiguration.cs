using AdsService.Application.Models.Entities;
using AdsService.Application.Models.ValueObjects;
using AdsService.Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsService.Infrastructure.Persistence.EntityConfigurations;

public class CheckEntityConfiguration : IEntityTypeConfiguration<Check>
{
    public void Configure(EntityTypeBuilder<Check> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Reason).HasConversion<ReasonConverter>().HasMaxLength(Reason.MaxLength);
        builder.Property(e => e.Result);
        
        builder.HasOne<Moderator>(e => e.Moderator).WithMany().IsRequired();
        builder.HasOne<Post>(e => e.Post).WithMany().IsRequired();
    }
}