using Notify.Services;
using Notify.Services.Interfaces;
using Notify.Tests.Shared;
using Notify.Validators;

namespace Notify.Tests
{
    public class ContractTests
    {
        private readonly INotifiableContext _context;
        public ContractTests()
        {
            _context = new NotifiableContext();
        }

        [Fact]
        public void Contract_ShouldBeTrue_Must_Add_Notication_When_Comparism_Return_False()
        {
            var contract = new Contract(_context);
            new NotificationMessagesConfiguation(new[] { Common.notificationParamertersSetup, Common.noticationParamertersSetup2 });

            var expecteNotification = Common.notificationParamertersSetup.First();

            contract.ShouldBeTrue(Comparator.String.IsNull(nameof(Contract_ShouldBeTrue_Must_Add_Notication_When_Comparism_Return_False)), expecteNotification.Key);

            Assert.True(_context.Invalid);
            Assert.True(_context.Notifications.Count == 1);
            var notification = _context.Notifications.First();
            Assert.True(notification.Key == expecteNotification.Key);
            Assert.True(notification.Message == expecteNotification.Value.Message);
        }

        [Fact]
        public void Contract_ShouldBeTrue_Must_Not_Add_Notication_When_Comparism_Return_True()
        {
            var contract = new Contract(_context);
            new NotificationMessagesConfiguation(new[] { Common.notificationParamertersSetup, Common.noticationParamertersSetup2 });

            var expecteNotification = Common.notificationParamertersSetup.First();

            contract.ShouldBeTrue(Comparator.String.IsNotNull(nameof(Contract_ShouldBeTrue_Must_Add_Notication_When_Comparism_Return_False)), expecteNotification.Key);

            Assert.True(_context.Valid);
            Assert.True(_context.Notifications.Count == 0);
        }

        [Fact]
        public void Contract_ShouldNotBeTrue_Must_Add_Notication_When_Comparism_Return_True()
        {
            var contract = new Contract(_context);
            new NotificationMessagesConfiguation(new[] { Common.notificationParamertersSetup, Common.noticationParamertersSetup2 });

            var expecteNotification = Common.notificationParamertersSetup.First();

            contract.ShouldNotBeTrue(Comparator.String.IsNotNull(nameof(Contract_ShouldBeTrue_Must_Add_Notication_When_Comparism_Return_False)), expecteNotification.Key);

            Assert.True(_context.Invalid);
            Assert.True(_context.Notifications.Count == 1);
            var notification = _context.Notifications.First();
            Assert.True(notification.Key == expecteNotification.Key);
            Assert.True(notification.Message == expecteNotification.Value.Message);
        }

        [Fact]
        public void Contract_ShouldNotBeTrue_Must_NotAdd_Notication_When_Comparism_Return_False()
        {
            var contract = new Contract(_context);
            new NotificationMessagesConfiguation(new[] { Common.notificationParamertersSetup, Common.noticationParamertersSetup2 });

            var expecteNotification = Common.notificationParamertersSetup.First();

            contract.ShouldNotBeTrue(Comparator.String.IsNotNull(default!),expecteNotification.Key);

            Assert.True(_context.Valid);
            Assert.True(_context.Notifications.Count == 0);
        }
    }
}