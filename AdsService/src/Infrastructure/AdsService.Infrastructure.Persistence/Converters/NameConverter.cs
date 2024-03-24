using AdsService.Application.Models.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdsService.Infrastructure.Persistence.Converters;

public class NameConverter : ValueConverter<Name, string>
{
    public NameConverter() : base(
        v => v.Value,
        v => new Name(v)) { }
}