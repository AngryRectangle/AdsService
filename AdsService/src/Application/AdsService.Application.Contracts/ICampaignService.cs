using AdsService.Application.Models.Dto;

namespace AdsService.Application.Contracts;

public interface ICampaignService
{
    public AdCampaignDto StartCampaign(Jwt jwt, Guid postId);
    public AdCampaignDto StopCampaign(Jwt jwt, Guid postId);
    public IEnumerable<AdCampaignDto> GetAllCampaigns(Jwt jwt);
}