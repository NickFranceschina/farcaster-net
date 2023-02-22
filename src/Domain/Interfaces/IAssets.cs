namespace FarcasterNet.Domain.Interfaces;

using System.Threading;
using System.Threading.Tasks;
using FarcasterNet.Domain.Models;

// NOTE: these are actually "collections"???
public interface IAssets
{
    Task<List<Asset>> GetUserAssets(string ownerId, int limit, string cursor, CancellationToken cancellationToken);

    Task<Asset> GetAssetById(string assetId, CancellationToken cancellationToken);

    Task<bool> AssetExists(string assetId, CancellationToken cancellationToken);

    Task<List<User>> GetAssetOwners(string assetId, int limit, string cursor, CancellationToken cancellationToken);

}
