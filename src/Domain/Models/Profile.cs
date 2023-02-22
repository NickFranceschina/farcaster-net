namespace FarcasterNet.Domain.Models;

public partial class Profile
{
    public Bio Bio { get; set; }
}

public partial class Bio
{
    public string Text { get; set; }
    public object[] Mentions { get; set; }
}
