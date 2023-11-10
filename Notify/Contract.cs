using Notify.Interfaces;

namespace Notify
{
    public class Contract 
    {
        public Contract(Notifiable entity)
        {
            notifiableEntity = entity; 
        }


        private readonly Notifiable notifiableEntity;
        public Contract ShouldBeTrue(bool value, long key)
        {
            if (!value)
                notifiableEntity.AddNotification(new NotificationItem(string.Empty, key));

            return this;
        }
        public Contract ShouldNotBeTrue(bool value,  long key) =>
            ShouldBeTrue(!value, key);
        public Contract ShouldBeTrue(Func<bool> action, long key) =>
            ShouldBeTrue(action(),key);
        public Contract ShouldNotBeTrue(Func<bool> action, long key) =>
            ShouldNotBeTrue(action(),key);  

    }
}
