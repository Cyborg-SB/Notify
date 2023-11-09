using Notify.Extensions;
using System.Collections.Generic;

namespace Notify
{
    public class NotificationMessagesConfiguation
    {
        private NotificationMessagesConfiguation(Dictionary<long, NotificationParameters> messagesConfiguration)
        {
            MessagesConfiguation = messagesConfiguration;
        }
        public static void SetupMessagesConfiguration(Dictionary<long, NotificationParameters> messagesConfiguration)
        {
            if (Instance is not null)
                throw new Exception($"{nameof(NotificationMessagesConfiguation)} já inicializado");

            Instance = new NotificationMessagesConfiguation(messagesConfiguration);
        }

        public static void SetupMessagesConfiguration(Dictionary<long, NotificationParameters>[] messagesConfigurations)
        {
            if (Instance is not null)
                throw new Exception($"{nameof(NotificationMessagesConfiguation)} já inicializado");

            Dictionary<long, NotificationParameters> consolidatedNotificationParameters = new Dictionary<long, NotificationParameters>();

            messagesConfigurations.ForEach(currentDicionary => { consolidatedNotificationParameters.AddRange(currentDicionary); });

            Instance = new NotificationMessagesConfiguation(consolidatedNotificationParameters);
        }

        internal static NotificationMessagesConfiguation Instance;

        public Dictionary<long, NotificationParameters> MessagesConfiguation { get; private set; }
    }
}
