namespace FarcasterNet.Application.Casts.Entities;

using Application.Common.Entities;
using AutoMapper;

public record Cast : FcEntity
{
    // add properties here from the Domain/Models/Cast.cs file
    public string Hash { get; set; }
    public string ThreadHash { get; set; }
    public string ParentHash { get; set; }
    public User ParentAuthor { get; set; }
    public User Author { get; set; }
    public string Text { get; set; }
    public long Timestamp { get; set; } 

    public int RepliesCount { get; set; }
    public int ReactionsCount { get; set; }
    public int RecastsCount { get; set; }

    // public Reactions Watches { get; set; }
    // public CastViewerContext ViewerContext { get; set; }

    public bool ViewerContextReacted { get; set; }
    public bool ViewerContextRecast { get; set; }

    public object FirstOpenGraphAttachment { get; set; }
}

internal class CastMappingProfile : Profile
{
    public CastMappingProfile()
    {
        _ = this.CreateMap<Domain.Models.Cast, Cast>()
            .ReverseMap()
       ;
    }
}


