using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify
{
    public class Contract : Notifiable
    {
        public Contract()
        {
        }

        public Contract NotGreatherThan (int valueToBeCompared, int valueToConfront, long key)
        {
            if (valueToBeCompared > valueToConfront)
                AddNotification(new NotificationItem(string.Empty, key));

            return this;

        }
        public Contract NotLowerThan(int valueToBeCompared, int valueToConfront, long key)
        {
            if (valueToBeCompared < valueToConfront)
                AddNotification(new NotificationItem(string.Empty, key));

            return this;

        }

        public Contract NotGreatherOrEqualThan(int valueToBeCompared, int valueToConfront, long key)
        {
            if (valueToBeCompared >= valueToConfront)
                AddNotification(new NotificationItem(string.Empty, key));

            return this;

        }
        public Contract NotLowerOrEqualThan(int valueToBeCompared, int valueToConfront, long key)
        {
            if (valueToBeCompared <= valueToConfront)
                AddNotification(new NotificationItem(string.Empty, key));

            return this;

        }

    }
}
