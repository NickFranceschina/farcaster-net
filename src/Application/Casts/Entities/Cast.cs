namespace FarcasterNet.Application.Casts.Entities;

using Application.Common.Entities;
using AutoMapper;

public record Cast : FcEntity
{
    // add properties here from the Domain/Models/Cast.cs file
    public string Hash { get; set; }
    public string ThreadHash { get; set; }
    public string ParentHash { get; set; }
    // public User ParentAuthor { get; set; }
    // public User Author { get; set; }
    public string Text { get; set; }
    public long Timestamp { get; set; }
    public DateTime TimestampUtc { get; set; }
    // public Reactions Replies { get; set; }
    // public Reactions Reactions { get; set; }
    // public Recasts Recasts { get; set; }
    // public Reactions Watches { get; set; }
    // public CastViewerContext ViewerContext { get; set; }
}

internal class AuthorMappingProfile : Profile
{
    public AuthorMappingProfile()
    {
        _ = this.CreateMap<FarcasterNet.Domain.Models.Cast, Cast>()
            .ReverseMap();
    }
}


