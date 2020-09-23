using Architecture.Domain;
using Architecture.Model;
using System;
using System.Linq.Expressions;

namespace Architecture.Database
{
    public static class NotificationExpression
    {
        public static Expression<Func<Notification, NotificationModel>> Model => Notify => new NotificationModel
        {
            Id = Notify.Id,
            ContactTo = Notify.ContactTo,
            Message = Notify.Message,
            State = (int)Notify.State,
            Type = (int)Notify.Type
            
        };

        public static Expression<Func<Notification, bool>> Id(long id)
        {
            return CheckHistory => CheckHistory.Id == id;
        }
        public static Expression<Func<Notification, bool>> Waiting(NotificationState state)
        {
            return Notification =>Notification.State== (NotificationState)state;
        }
    }
}
