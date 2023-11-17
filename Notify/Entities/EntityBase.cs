using System.Diagnostics.CodeAnalysis;

namespace Notify.Entities
{
    [ExcludeFromCodeCoverage]
    public abstract class EntityBase : Notifiable
    {
        protected new void AddNotification(NotificationItem notification) =>
           base.AddNotification(notification);

        protected new void AddNotification(string message, long key, string propertyValue) =>
            base.AddNotification(message, key, propertyValue);
        protected new void AddNotifications(IEnumerable<NotificationItem> notificationItems) =>
            base.AddNotifications(notificationItems);
    }
}
