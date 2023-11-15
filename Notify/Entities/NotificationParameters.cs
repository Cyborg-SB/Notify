using System.Net;
using Notify.Enums;

namespace Notify.Entities
{
    public class NotificationParameters
    {
        public NotificationParameters(string message, string propertyName, HttpStatusCode statusCode, NotificationSeverity notificationSeverity)
        {
            Message = message;
            PropertyName = propertyName;
            NotificationSeverity = notificationSeverity;
            StatusCode = statusCode;
        }
        public string Message { get; private set; }
        public string PropertyName { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public NotificationSeverity NotificationSeverity { get; private set; }


    }
}
