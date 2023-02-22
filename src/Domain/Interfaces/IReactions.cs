namespace FarcasterNet.Domain.Interfaces;

using System.Threading;
using System.Threading.Tasks;
using FarcasterNet.Domain.Models;

public interface IReactions
{
    Task<List<Reaction>> GetReactions(CancellationToken cancellationToken);

    Task<Reaction> GetReactionById(Guid id, CancellationToken cancellationToken);

    Task<bool> ReactionExists(Guid id, CancellationToken cancellationToken);
}
