using AdsService.Application.Models.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdsService.Infrastructure.Persistence.Converters;

public class MoneyConverter : ValueConverter<Money, long>
{
    public MoneyConverter() : base(
        v => v.Kopecks,
        v => new Money(v))
    {
    }
}