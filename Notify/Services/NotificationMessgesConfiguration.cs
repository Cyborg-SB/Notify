using Notify.Entities;
using Notify.Excetpions;
using Notify.Extensions;
using Notify.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Notify.Services
{

    public class NotificationMessagesConfiguation : INotificationMessagesConfiguation
    {
        internal NotificationMessagesConfiguation(IDictionary<long, NotificationParameters> messagesConfiguration)
        {
            MessagesConfiguation = SetupMessagesConfiguration(messagesConfiguration);
            InternalMessagesConfiguration = MessagesConfiguation;

        }

        internal NotificationMessagesConfiguation(IDictionary<long, NotificationParameters>[] messagesConfiguration)
        {
            MessagesConfiguation = SetupMessagesConfiguration(messagesConfiguration);
            InternalMessagesConfiguration = MessagesConfiguation;
        }
        public static IDictionary<long, NotificationParameters> SetupMessagesConfiguration(IDictionary<long, NotificationParameters> messagesConfiguration)
        {
            ValidateNotificationDicionary(messagesConfiguration);

            return messagesConfiguration;
        }

        internal static IDictionary<long, NotificationParameters> SetupMessagesConfiguration(IDictionary<long, NotificationParameters>[] messagesConfigurations)
        {
            Dictionary<long, NotificationParameters> consolidatedNotificationParameters = new();

            messagesConfigurations.ForEach(currentDicionary => 
            {
                ValidateNotificationDicionary(currentDicionary);

                consolidatedNotificationParameters.AddRange(currentDicionary); 
            });

            return consolidatedNotificationParameters;
        }
     
        [ExcludeFromCodeCoverage]
        internal static void ValidateNotificationDicionary(IDictionary<long, NotificationParameters> notificationParameters)
        {
            if (notificationParameters is null)
                throw new InvalidNotificationsDicionaryException();
        }

        internal static IDictionary<long, NotificationParameters> InternalMessagesConfiguration { get; private set; } = default!;

        internal IDictionary<long, NotificationParameters> MessagesConfiguation { get; private set; }

    }
}
