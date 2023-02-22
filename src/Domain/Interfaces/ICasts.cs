namespace FarcasterNet.Domain.Interfaces;

using FarcasterNet.Domain.Models;

public interface ICasts
{
    Task<List<Cast>> GetDefaultRecommendedFeed(int limit, string cursor, CancellationToken cancellationToken);
    Task<List<Cast>> GetCasts(CancellationToken cancellationToken);
    Task<Cast> GetCastById(string castHash, CancellationToken cancellationToken);
    Task<bool> CastExists(string castHash, CancellationToken cancellationToken);
}
