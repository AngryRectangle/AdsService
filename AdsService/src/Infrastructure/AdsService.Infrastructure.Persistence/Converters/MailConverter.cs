using AdsService.Application.Models.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdsService.Infrastructure.Persistence.Converters;

public class MailConverter : ValueConverter<UserMail, string>
{
    public MailConverter() : base(
        v => v.Mail,
        v => new UserMail(v))
    {
    }
}