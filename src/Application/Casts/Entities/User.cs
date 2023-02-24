namespace FarcasterNet.Application.Casts.Entities;

using Application.Common.Entities;
using AutoMapper;

public record User : FcEntity
{
    public long Fid { get; set; }
    public string Username { get; set; }
    public string DisplayName { get; set; }
    public long FollowerCount { get; set; }
    public long FollowingCount { get; set; }
    public string ReferrerUsername { get; set; }

    // public Pfp Pfp { get; set; }
    //public Profile Profile { get; set; }
    public string PfpUrl { get; set; }
    public string PfpVerified { get; set; }
    public string ProfileBioText { get; set; }
    public object ProfileLocation { get; set; }
}

internal class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        _ = this.CreateMap<Domain.Models.User, User>()
            .ReverseMap();
    }
}


