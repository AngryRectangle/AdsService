using AdsService.Application.Models.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdsService.Infrastructure.Persistence.Converters;

public class PostContentConverter : ValueConverter<PostContent, string>
{
    public PostContentConverter() : base(
        v => v.Text,
        v => new PostContent(v))
    {
    }
}