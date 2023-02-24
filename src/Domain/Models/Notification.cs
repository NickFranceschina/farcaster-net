namespace FarcasterNet.Domain.Models;

public partial class Notification
{
    public NotificationType Type { get; set; }
    public string Id { get; set; }
    public long Timestamp { get; set; }
    // public DateTime TimestampUtc => DateTimeOffset.FromUnixTimeMilliseconds(Timestamp).UtcDateTime;
    public User Actor { get; set; }
    public Content Content { get; set; }
}

public partial class Content
{
    public Cast Cast { get; set; }
}

public enum NotificationType
{
    Mention,
    Reaction,
    Recast,
    Follow,
    DirectCast
}

