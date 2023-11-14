namespace Notify
{
    public class NotificationItem
    {
        internal NotificationItem(string message, long key = 0, string propertyValue = "")
        {
            Message = message;
            Key = key;
            PropertyValue = propertyValue;
        }

        public string Message { get; private set; }
        public long Key { get; private set; }
        public string PropertyValue { get; private set; }

    }
}
