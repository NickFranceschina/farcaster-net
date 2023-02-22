namespace FarcasterNet.Domain.Models;

public partial class User
{
    public long Fid { get; set; }
    public string Username { get; set; }
    public string DisplayName { get; set; }
    public Pfp Pfp { get; set; }
    public Profile Profile { get; set; }
    public long FollowerCount { get; set; }
    public long FollowingCount { get; set; }
    public string ReferrerUsername { get; set; }
    public UserViewerContext ViewerContext { get; set; }
}

public partial class UserViewerContext
{
    public bool Following { get; set; }
    public bool FollowedBy { get; set; }
    public bool? CanSendDirectCasts { get; set; }
}

public partial class Pfp
{
    public Uri Url { get; set; }
    public bool Verified { get; set; }
}

