using AdsService.Application.Models.Entities;
using AdsService.Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsService.Infrastructure.Persistence.EntityConfigurations;

public class AdCampaignConfiguration : IEntityTypeConfiguration<AdCampaign>
{
    public void Configure(EntityTypeBuilder<AdCampaign> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.StartedAt);
        builder.Property(e => e.Duration);
        builder.Property(e => e.IsActive);
        builder.Property(e => e.Cost).HasConversion<MoneyConverter>();

        builder.HasOne<Post>().WithMany().IsRequired();
    }
}