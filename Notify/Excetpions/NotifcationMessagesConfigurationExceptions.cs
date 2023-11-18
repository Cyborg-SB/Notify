using System.Diagnostics.CodeAnalysis;

namespace Notify.Excetpions
{
    [ExcludeFromCodeCoverage]
    public class MessagesConfigurationInstanceAlreadyInitializedException : Exception
    {
        public MessagesConfigurationInstanceAlreadyInitializedException() : base("Notification Messages Configuration is already initialized") { }
      
    }
    [ExcludeFromCodeCoverage]
    public class InvalidNotificationsDicionaryException : Exception
    {
        public InvalidNotificationsDicionaryException() : base("Notification dicionary cast be null") { }

    }
}
