namespace FarcasterNet.Domain.Models;

public partial class Profile
{
    public Bio Bio { get; set; }
    public Location Location { get; set; }
}

public partial class Bio
{
    public string Text { get; set; }
    public object[] Mentions { get; set; }
}

public partial class Location
{
    public string Description { get; set; }
    public string PlaceId { get; set; }
}
