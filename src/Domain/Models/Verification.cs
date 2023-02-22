namespace FarcasterNet.Domain.Models;

public partial class Verification
{
    public long Fid { get; set; }
    public string Address { get; set; }
    public long Timestamp { get; set; }
    public DateTime TimestampUtc => DateTimeOffset.FromUnixTimeMilliseconds(Timestamp).UtcDateTime;
}

