using Notify.Entities;
using Notify.Enums;
using Notify.Excetpions;
using Notify.Services;
using Notify.Tests.Shared;
using System.Net;

namespace Notify.Tests
{
    public class NotificationMessagesConfigurationTests
    {
        [Fact]
        public void SetupMessagesConfiguarion_Should_Create_Messages_Configuration_Instance_With_Success()
        {
            Dictionary<long, NotificationParameters> noticationParamertersSetup = new()
            {
                { 1, new NotificationParameters(nameof(NotificationMessagesConfigurationTests),  nameof(noticationParamertersSetup), HttpStatusCode.UnprocessableEntity, NotificationSeverity.Warning) }
            };

            var key = noticationParamertersSetup.Keys.First();

            NotificationMessagesConfiguation.SetupMessagesConfiguration(noticationParamertersSetup);

            ValidateNotificationMessagesConfiguration(new[] { key});

            Common.ShutDownMessagesConfigurationInstance();
        }

        [Fact]
        public void SetupMessagesConfiguarionArray_Should_Create_Messages_Configuration_Instance_With_Sucess()
        {
            
            var key1 = Common.noticationParamertersSetup.Keys.First();
            var key2 = Common.noticationParamertersSetup2.Keys.First();

            NotificationMessagesConfiguation.SetupMessagesConfiguration( new[] { Common.noticationParamertersSetup, Common.noticationParamertersSetup2 });

            ValidateNotificationMessagesConfiguration(new[] { key1, key2 });

            Common.ShutDownMessagesConfigurationInstance();
        }


        [Fact]
        public void SetupMessagesConfiguarion_Should_Thorw_Exception_Messages_Configuration_Parameter_Is_null()
        {
            Assert.Throws<InvalidNotificationsDicionaryException>( () => NotificationMessagesConfiguation.SetupMessagesConfiguration((IDictionary<long, NotificationParameters>)default!));


            Common.ShutDownMessagesConfigurationInstance();
        }

        [Fact]
        public void SetupMessagesConfiguarionArray_Should_Thorw_Exception_Messages_Configuration_Parameter_Is_null()
        {
            Assert.Throws<InvalidNotificationsDicionaryException>(() => NotificationMessagesConfiguation.SetupMessagesConfiguration(new IDictionary<long, NotificationParameters>[] { default! }));

            Common.ShutDownMessagesConfigurationInstance();
        }

        [Fact]
        public void SetupMessagesConfiguarion_Should_Thorw_Exception_Messages_Configuration_Instance_Is_Already_Initialized()
        {

            Dictionary<long, NotificationParameters> noticationParamertersSetup = new()
            {
                { 1, 
                    new NotificationParameters(
                        nameof(NotificationMessagesConfigurationTests),  
                        nameof(noticationParamertersSetup), 
                        HttpStatusCode.UnprocessableEntity, 
                        NotificationSeverity.Warning) }
            };

            NotificationMessagesConfiguation.SetupMessagesConfiguration(noticationParamertersSetup);

            Assert.Throws<MessagesConfigurationInstanceAlreadyInitializedException>(() => NotificationMessagesConfiguation.SetupMessagesConfiguration(noticationParamertersSetup));


            Common.ShutDownMessagesConfigurationInstance();
        }

        private static void ValidateNotificationMessagesConfiguration(IEnumerable<long> keys)
        {
            foreach (var key in keys) {
                Assert.True(NotificationMessagesConfiguation.Instance is not null);
                Assert.True(NotificationMessagesConfiguation.Instance.MessagesConfiguation.TryGetValue(key, out NotificationParameters? notificationParameters));
                Assert.True(notificationParameters is not null);
            } 
        }
    }
}