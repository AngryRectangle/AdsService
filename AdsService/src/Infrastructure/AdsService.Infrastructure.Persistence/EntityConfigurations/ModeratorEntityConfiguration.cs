using AdsService.Application.Models.Entities;
using AdsService.Application.Models.ValueObjects;
using AdsService.Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsService.Infrastructure.Persistence.EntityConfigurations;

public class ModeratorEntityConfiguration : IEntityTypeConfiguration<Moderator>
{
    public void Configure(EntityTypeBuilder<Moderator> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Mail).HasConversion<MailConverter>().HasMaxLength(UserMail.MaxLength);
        builder.Property(e => e.Password)
            .HasConversion<PasswordHashConverter>()
            .HasMaxLength(PasswordHash.HashHexSize)
            .IsFixedLength()
            .IsUnicode(false)
            .IsRequired();
    }
}