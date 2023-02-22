namespace FarcasterNet.Domain.Interfaces;

using System.Threading;
using System.Threading.Tasks;
using FarcasterNet.Domain.Models;

public interface IUsers
{
    Task<List<User>> GetUsers(CancellationToken cancellationToken);
    Task<User> GetUserById(Guid id, CancellationToken cancellationToken);
    Task<bool> UserExists(Guid id, CancellationToken cancellationToken);
}

