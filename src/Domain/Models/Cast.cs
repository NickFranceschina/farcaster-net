namespace FarcasterNet.Domain.Models;

public partial class Cast
{
    public string Hash { get; set; }
    public string ThreadHash { get; set; }
    public string ParentHash { get; set; }
    public User ParentAuthor { get; set; }
    public User Author { get; set; }
    public string Text { get; set; }
    public long Timestamp { get; set; }
    public DateTime TimestampUtc => DateTimeOffset.FromUnixTimeSeconds(Timestamp).UtcDateTime;
    public Reactions Replies { get; set; }
    public Reactions Reactions { get; set; }
    public Recasts Recasts { get; set; }
    public Reactions Watches { get; set; }
    public CastViewerContext ViewerContext { get; set; }
}

public partial class CastViewerContext
{
    public bool Reacted { get; set; }
    public bool Recast { get; set; }
    public bool Watched { get; set; }
}

public partial class Recasts
{
    public long Count { get; set; }
    public object[] Recasters { get; set; }
}
