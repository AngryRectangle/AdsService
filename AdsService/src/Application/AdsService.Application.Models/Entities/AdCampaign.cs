namespace AdsService.Application.Models.Entities;

using AdsService.Application.Models.ValueObjects;

public class AdCampaign
{
    public AdCampaign(Money cost, Post post, DateTime startedAt, TimeSpan duration, bool isActive)
    {
        Post = post;
        Cost = cost;
        StartedAt = startedAt;
        Duration = duration;
        IsActive = isActive;
    }

    /// <summary>
    /// Конструктор для EF Core
    /// </summary>
    private AdCampaign()
    {
        Post = null!;
    }

    public Guid Id { get; } = Guid.NewGuid();

    public Post Post { get; }

    public Money Cost { get; }

    public DateTime StartedAt { get; }

    public TimeSpan Duration { get; }

    public bool IsActive { get; }
}