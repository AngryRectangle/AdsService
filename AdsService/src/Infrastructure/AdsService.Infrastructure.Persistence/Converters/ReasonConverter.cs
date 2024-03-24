using AdsService.Application.Models.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdsService.Infrastructure.Persistence.Converters;

public class ReasonConverter : ValueConverter<Reason, string>
{
    public ReasonConverter() : base(
        v => v.Value,
        v => new Reason(v))
    {
    }
}