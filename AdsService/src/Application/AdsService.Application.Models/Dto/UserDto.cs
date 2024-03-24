namespace AdsService.Application.Models.Dto;

using AdsService.Application.Models.ValueObjects;

public record UserDto(Guid Id, Name Name, Money Balance);