using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Interfaces
{
    public interface INotifiableContext
    {
        public IReadOnlyCollection<NotificationItem> Notifications { get; }
        public bool Valid { get;  } 
        public bool Invalid { get;  } 
        public void AddNotification(NotificationItem notificationItem);
        public void AddNotification(string message, long key = 0, string propertyValue = "");
        public void AddNotifications(IEnumerable<NotificationItem> notificationItems);
    }
}
