using Notify.Entities;

namespace Notify.Dtos
{
    public class NotifiableResultReponse 
    {
        internal NotifiableResultReponse(int statusCode, string message, IReadOnlyCollection<NotificationMessageResult> notificationItems)
        {
            StatusCode = statusCode;
            Message = message;
            Fields = notificationItems;
        }
        public int StatusCode { get; internal set; }
        public string Message { get; internal set; } 
        public IReadOnlyCollection<NotificationMessageResult> Fields { get; internal set; }
        
       
    }    
}
