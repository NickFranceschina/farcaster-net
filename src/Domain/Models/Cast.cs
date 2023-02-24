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
    // public DateTime TimestampUtc => DateTimeOffset.FromUnixTimeMilliseconds(this.Timestamp).UtcDateTime;
    public Reactions Replies { get; set; }
    public Reactions Reactions { get; set; }
    public Recasts Recasts { get; set; }
    public Reactions Watches { get; set; }
    public CastViewerContext ViewerContext { get; set; }
    public Attachments Attachments { get; set; }
    public object FirstOpenGraphAttachment => this.Attachments?.OpenGraph?.FirstOrDefault();
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

public partial class Attachments
{
    public OpenGraph[] OpenGraph { get; set; }
}

public partial class OpenGraph
{
    public string Description { get; set; }
    public string Domain { get; set; }
    public string Image { get; set; }
    public string Logo { get; set; }
    public string StrippedCastText { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public bool UseLargeImage { get; set; }
}
