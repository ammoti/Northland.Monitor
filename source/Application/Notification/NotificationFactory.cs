using System;
using Architecture.Domain;
using Architecture.Model;

namespace Architecture.Application
{
    public class NotificationFactory : INotificationFactory
    {
        public Notification Create(NotificationModel model)
        {
            return new Notification
            (model.Message, model.ContactTo, (NotificationState)model.State, (NotificationType)model.Type
            );
        }
    }
}
