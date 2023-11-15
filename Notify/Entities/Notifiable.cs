using Notify.Services;
using Notify.Services.Interfaces;

namespace Notify.Entities
{
    public abstract class Notifiable
    {
        private readonly List<NotificationItem> notifications = new();
        public bool Valid { get { return notifications.Count == 0; } }
        public bool Invalid { get { return !Valid; } }
        public IReadOnlyCollection<NotificationItem> Notifications { get { return notifications; } }

        public virtual void Validate() { }
        public virtual void Validate(INotifiableContext notifiable) { }


        internal void AddNotification(NotificationItem notification) =>
            notifications.Add(GetNotificationParameters(notification));

        internal void AddNotification(string message, long key, string propertyValue) =>
            notifications.Add(GetNotificationParameters(message, key, propertyValue));
        internal void AddNotifications(IEnumerable<NotificationItem> notificationItems) =>
            notifications.AddRange(notificationItems);

        private static NotificationItem GetNotificationParameters(NotificationItem notification) =>
             GetNotificationParameters(notification.Message, notification.Key, notification.PropertyValue);

        private static NotificationItem GetNotificationParameters(string message, long key = 0, string propertyValue = "")
        {
            if (key != 0 && NotificationMessagesConfiguation.Instance!.MessagesConfiguation.TryGetValue(key, out var value))
            {
                if (string.IsNullOrWhiteSpace(message))
                    return new NotificationItem(value.Message, key, propertyValue);

            }
            return new NotificationItem(message, key, propertyValue);
        }

    }

}