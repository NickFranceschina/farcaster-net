namespace FarcasterNet.Domain.Interfaces;

using System.Threading;
using System.Threading.Tasks;
using FarcasterNet.Domain.Models;

public interface INotifications
{
    Task<List<Notification>> GetNotifications(CancellationToken cancellationToken);
    Task<Notification> GetNotificationById(Guid id, CancellationToken cancellationToken);
    Task<bool> NotificationExists(Guid id, CancellationToken cancellationToken);
}
