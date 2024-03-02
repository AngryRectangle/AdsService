using AdsService.Application.Models.Dto;

namespace AdsService.Application.Contracts;

public interface IModerationService
{
    public PostDto Approve(Jwt jwt, Guid postId);
    public PostDto Reject(Jwt jwt, Guid postId);
}