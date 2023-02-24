namespace FarcasterNet.Domain.Models;

public partial class Reaction
{
    public ReactionType Type { get; set; }
    public string Hash { get; set; }
    public User Reactor { get; set; }
    public long Timestamp { get; set; }
    // public DateTime TimestampUtc => DateTimeOffset.FromUnixTimeMilliseconds(Timestamp).UtcDateTime;
    public string CastHash { get; set; }
}

public enum ReactionType
{
    Watch,
    Like,
    Dislike,
    Love,
    Haha,
    Wow,
    Sad,
    Angry
}

public partial class Reactions
{
    public long Count { get; set; }
    public Reaction[] Items { get; set; }
}

