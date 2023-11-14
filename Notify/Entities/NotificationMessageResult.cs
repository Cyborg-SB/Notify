
using System.Net;
using System.Text.Json.Serialization;
using Notify.Enums;

namespace Notify.Entities
{
    public class NotificationMessageResult
    {
        internal NotificationMessageResult(string message, long key, string propertyName, string propertyValue, NotificationSeverity severity, HttpStatusCode statusCode)
        {
            Message = message;
            Key = key;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            Severity = severity;
            StatusCode = statusCode;

        }

        public string Message { get; private set; }
        [JsonIgnore]
        public long Key { get; private set; }
        public string PropertyName { get; private set; }
        public string PropertyValue { get; private set; }
        [JsonIgnore]
        public NotificationSeverity Severity { get; private set; }
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; private set; }
    }
}
