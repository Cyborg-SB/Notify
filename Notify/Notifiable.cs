using Notify.Interfaces;

namespace Notify
{
    public abstract class Notifiable
    {
        private List<NotificationItem> notifications = new List<NotificationItem>();        
        public bool Valid { get { return notifications.Count == 0; } }
        public bool Invalid { get { return !Valid; } }
        public IReadOnlyCollection<NotificationItem> Notifications { get { return notifications; } }

        public virtual void Validate() { }
        public virtual void Validate(INotifiableContext notifiable) { }
        public void AddNotification(NotificationItem notification) =>
            notifications.Add(GetNotificationParameters(notification));

        public void AddNotification(string message, long key, string propertyValue)  =>
            notifications.Add(GetNotificationParameters(message, key, propertyValue));
        public void AddNotifications(IEnumerable<NotificationItem> notificationItems) =>
            notifications.AddRange(notificationItems);

        private NotificationItem GetNotificationParameters(NotificationItem notification)=>
             GetNotificationParameters(notification.Message, notification.Key, notification.PropertyValue);
        
        private NotificationItem GetNotificationParameters(string message, long key = 0 ,string propertyValue = "")
        {
            if (key != 0 && NotificationMessagesConfiguation.Instance.MessagesConfiguation.TryGetValue(key, out NotificationParameters value))
            {
                if(string.IsNullOrWhiteSpace(message))
                    return value;
 
            }
            return new NotificationItem(message, key, propertyValue);
        }

    }

}