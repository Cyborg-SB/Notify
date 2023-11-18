using Notify.Dtos;
using Notify.Extensions;
using Notify.Services;
using Notify.Services.Interfaces;
using Notify.Tests.Shared;
using System.Net;
using System.Reflection;

namespace Notify.Tests
{
    public class NotifiableFilterExtensionsTests
    {
        private readonly INotifiableContext _context;
        public NotifiableFilterExtensionsTests()
        {
            _context = new NotifiableContext();
        }

        [Fact]
        public void GetNotifiableResultReponseMessages_Should_Return_NotifiableResultReponse_Instance_When_Notifications_Were_Raised()
        {
            _ = new NotificationMessagesConfiguation(Common.notificationParamertersSetup);
            var key = Common.notificationParamertersSetup.Keys.First();
            _context.AddNotification(string.Empty, key);

            var privateMethod = typeof(NotifiableFilterExtensions).GetTypeInfo().GetDeclaredMethod("GetNotifiableResultReponseMessages");
            var parameters = new object[] { _context.Notifications};
            var resp = privateMethod.Invoke(privateMethod, parameters);
            var respConverted = (NotifiableResultReponse)resp!;
            Assert.True(respConverted is not null);
            Assert.True(respConverted.Message == Enum.GetName(typeof(HttpStatusCode),Common.notificationParamertersSetup.First().Value.StatusCode));
            Assert.True(respConverted.Fields.First().Message == Common.notificationParamertersSetup.First().Value.Message);

        }
    }
}