using Architecture.Domain;
using Architecture.Model;

namespace Architecture.Application
{
    public interface INotificationFactory
    {
        Notification Create(NotificationModel model);
    }
}
