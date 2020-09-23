using DotNetCore.Domain;
using System;

namespace Architecture.Domain
{
    public class Notification : Entity<long>
    {
        public Notification
        (
            string message,
            string contactTo,
            NotificationState state,
            NotificationType type
        )
        {
            Message = message;
            ContactTo = contactTo;
            State = state;
            Type = type;

        }
        public Notification(long id) : base(id) { }

        public string Message { get; private set; }

        public string ContactTo { get; private set; }
        public NotificationState State { get; private set; }
        public NotificationType Type { get; private set; }
        
        public void UpdateState(NotificationState state)
        {
            State = state;
        }
    }
}
