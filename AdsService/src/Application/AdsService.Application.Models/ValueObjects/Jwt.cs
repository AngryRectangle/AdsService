namespace AdsService.Application.Models.ValueObjects;

public struct Jwt
{
#pragma warning disable IDE0052
    private readonly string _jwt;
#pragma warning restore IDE0052

    public Jwt(string jwt)
    {
        _jwt = jwt;
    }
}