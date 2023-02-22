namespace FarcasterNet.Domain.Models;

public partial class Asset
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long ItemCount { get; set; }
    public long OwnerCount { get; set; }
    public long FarcasterOwnerCount { get; set; }
    public Uri ImageUrl { get; set; }
    public long VolumeTraded { get; set; }
    public Uri ExternalUrl { get; set; }
    public Uri OpenSeaUrl { get; set; }
    public string TwitterUsername { get; set; }
    public AssetSchema SchemaName { get; set; }
}

public enum AssetSchema
{
    ERC1155,
    ERC721
}

