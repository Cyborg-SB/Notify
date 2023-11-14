using Notify.Interfaces;

namespace Notify
{
    public class NotifiableContext : Notifiable, INotifiableContext
    {
        void INotifiableContext.AddNotification(NotificationItem notificationItem) =>
            AddNotification(notificationItem);        

        void INotifiableContext.AddNotification(string message, long key, string propertyValue) =>
            AddNotification(message, key, propertyValue);

        void INotifiableContext.AddNotifications(IEnumerable<NotificationItem> notificationItems) =>
            AddNotifications(notificationItems);
    }
}
