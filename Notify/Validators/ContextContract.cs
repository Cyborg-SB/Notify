using Notify.Entities;
using Notify.Services.Interfaces;

namespace Notify.Validators
{
    public class ContextContract
    {
        private readonly INotifiableContext notifiableContext;
        public ContextContract(INotifiableContext notifiableContext)
        {
            this.notifiableContext = notifiableContext;
        }

        public ContextContract ShouldBeTrue(bool value, long key)
        {
            if (!value)
                notifiableContext.AddNotification(new NotificationItem(string.Empty, key));

            return this;
        }
        public ContextContract ShouldNotBeTrue(bool value, long key) =>
            ShouldBeTrue(!value, key);
        public ContextContract ShouldBeTrue(Func<bool> action, long key) =>
            ShouldBeTrue(action(), key);
        public ContextContract ShouldNotBeTrue(Func<bool> action, long key) =>
            ShouldNotBeTrue(action(), key);


    }
}
