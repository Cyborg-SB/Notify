using Notify.Entities;
using Notify.Services.Interfaces;

namespace Notify.Validators
{
    public class Contract
    {
        public Contract(Notifiable entity)
        {
            _notifiable = entity;
        }

        public Contract(INotifiableContext notifiableContext)
        {
            _notifiable = (notifiableContext as Notifiable)!;
        }


        private readonly Notifiable _notifiable;
        public Contract ShouldBeTrue(bool value, long key)
        {
            if (!value)
                _notifiable.AddNotification(new NotificationItem(string.Empty, key));

            return this;
        }
        public Contract ShouldNotBeTrue(bool value, long key) =>
            ShouldBeTrue(!value, key);
        public Contract ShouldBeTrue(Func<bool> action, long key) =>
            ShouldBeTrue(action(), key);
        public Contract ShouldNotBeTrue(Func<bool> action, long key) =>
            ShouldNotBeTrue(action(), key);

    }
}
