using Notify.Entities;
using Notify.Excetpions;
using Notify.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Notify.Services
{
    public class NotificationMessagesConfiguation
    {
        private NotificationMessagesConfiguation(IDictionary<long, NotificationParameters> messagesConfiguration)
        {
            MessagesConfiguation = messagesConfiguration;
        }
        public static void SetupMessagesConfiguration(IDictionary<long, NotificationParameters> messagesConfiguration)
        {
            NotificationMessagesConfiguationInstance(Instance!);

            ValidateNotificationDicionary(messagesConfiguration);

            Instance = new NotificationMessagesConfiguation(messagesConfiguration);
        }

        public static void SetupMessagesConfiguration(IDictionary<long, NotificationParameters>[] messagesConfigurations)
        {
            NotificationMessagesConfiguationInstance(Instance!);

            Dictionary<long, NotificationParameters> consolidatedNotificationParameters = new();

            messagesConfigurations.ForEach(currentDicionary => 
            {
                ValidateNotificationDicionary(currentDicionary);

                consolidatedNotificationParameters.AddRange(currentDicionary); 
            });

            Instance = new NotificationMessagesConfiguation(consolidatedNotificationParameters);
        }
        [ExcludeFromCodeCoverage]
        internal static void NotificationMessagesConfiguationInstance(NotificationMessagesConfiguation notificationMessagesConfiguation)
        {
            if (notificationMessagesConfiguation is not null)
                throw new MessagesConfigurationInstanceAlreadyInitializedException();
        }
        [ExcludeFromCodeCoverage]
        internal static void ValidateNotificationDicionary(IDictionary<long, NotificationParameters> notificationParameters)
        {
            if (notificationParameters is null)
                throw new InvalidNotificationsDicionaryException();
        }

        internal static NotificationMessagesConfiguation? Instance;

        public IDictionary<long, NotificationParameters> MessagesConfiguation { get; private set; }
    }
}
