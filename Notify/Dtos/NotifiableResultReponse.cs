namespace Notify.Dtos
{
    public class NotifiableResultReponse 
    {
        internal NotifiableResultReponse(int statusCode, string message, IReadOnlyCollection<NotificationItem> notificationItems)
        {
            StatusCode = statusCode;
            Message = message;
            Fields = notificationItems;
        }
        public int StatusCode { get; private set; }
        public string Message { get; private set; } 
        public IReadOnlyCollection<NotificationItem> Fields { get; private set; }
        
    }    
}
