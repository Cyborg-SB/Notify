namespace Notify.Entities
{
    public abstract class EntityBase : Notifiable
    {
        protected new void AddNotification(NotificationItem notification) =>
           AddNotification(notification);

        protected new void AddNotification(string message, long key, string propertyValue) =>
            AddNotification(message, key, propertyValue);
        protected new void AddNotifications(IEnumerable<NotificationItem> notificationItems) =>
            AddNotifications(notificationItems);
    }
}
