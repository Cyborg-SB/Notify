using Notify.Entities;
using Notify.Excetpions;
using Notify.Services;
using Notify.Services.Interfaces;
using Notify.Tests.Shared;

namespace Notify.Tests
{
    public class NotificationMessagesConfigurationTests
    {

        public NotificationMessagesConfigurationTests()
        {
        }

        [Fact]
        public void SetupMessagesConfiguarion_Should_Create_Messages_Configuration_Instance_With_Success()
        {
          
            var key = Common.notificationParamertersSetup.Keys.First();

            _ = new NotificationMessagesConfiguation( Common.notificationParamertersSetup);

            ValidateNotificationMessagesConfiguration(new[] { key});

        }

        [Fact]
        public void SetupMessagesConfiguarionArray_Should_Create_Messages_Configuration_Instance_With_Sucess()
        {
            
            var key1 = Common.notificationParamertersSetup.Keys.First();
            var key2 = Common.noticationParamertersSetup2.Keys.First();

            _ = new NotificationMessagesConfiguation(new[] { Common.notificationParamertersSetup, Common.noticationParamertersSetup2 });
  

            ValidateNotificationMessagesConfiguration(new[] { key1, key2 });

        }


        [Fact]
        public void SetupMessagesConfiguarion_Should_Thorw_Exception_Messages_Configuration_Parameter_Is_null()
        {
            Assert.Throws<InvalidNotificationsDicionaryException>(() => new NotificationMessagesConfiguation((IDictionary<long, NotificationParameters>)default! ));
        }

        [Fact]
        public void SetupMessagesConfiguarionArray_Should_Thorw_Exception_Messages_Configuration_Parameter_Is_null()
        {
            Assert.Throws<InvalidNotificationsDicionaryException>(() => new NotificationMessagesConfiguation(new IDictionary<long, NotificationParameters>[] { default! }));
        }

        private static void ValidateNotificationMessagesConfiguration(IEnumerable<long> keys)
        {
            foreach (var key in keys) {
                Assert.True(NotificationMessagesConfiguation.InternalMessagesConfiguration is not null);
                Assert.True(NotificationMessagesConfiguation.InternalMessagesConfiguration.TryGetValue(key, out NotificationParameters? notificationParameters));
                Assert.True(notificationParameters is not null);
            } 
        }
    }
}