using AdsService.Application.Models.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdsService.Infrastructure.Persistence.Converters;

public class PasswordHashConverter : ValueConverter<PasswordHash, string>
{
    public PasswordHashConverter() : base(
        v => v.Password,
        v => new PasswordHash(v))
    {
    }
}