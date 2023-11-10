using Notify;
using Notify.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NotifyConsole
{
    public static class PersonalNotification
    {
        public static Dictionary<long, NotificationParameters> myNotifications = new Dictionary<long, NotificationParameters>()
        {
            { PersonalNotificationSeverity.failed_to_retrieve_response, new NotificationParameters("Erro ao recuperar responsa do serviço XPTO", string.Empty, HttpStatusCode.InternalServerError, NotificationSeverity.Error) },
            { PersonalNotificationSeverity.greater_value_error, new NotificationParameters("O Valor não deve ser maior", string.Empty, HttpStatusCode.InternalServerError, NotificationSeverity.Error) }
        };

        public static Dictionary<long, NotificationParameters> myNotifications2 = new Dictionary<long, NotificationParameters>()
        {
            { PersonalNotificationSeverity.warning_to_retrieve_response, new NotificationParameters("Erro ao recuperar responsa do serviço XPTO", string.Empty, HttpStatusCode.InternalServerError, NotificationSeverity.Error) },
            { PersonalNotificationSeverity.warning_greater_value_error, new NotificationParameters("O Valor não deve ser maior", string.Empty, HttpStatusCode.InternalServerError, NotificationSeverity.Error) }
        };

        public static class PersonalNotificationSeverity
        {
            public static long failed_to_retrieve_response = 10000000;
            public static long greater_value_error = 10000002;    
            public static long warning_to_retrieve_response = 10000001;
            public static long warning_greater_value_error = 10000003;
        }

        public class BaseEntity : Notifiable
        {
            public BaseEntity()
            {
                new Contract(this)
                   .ShouldBeTrue(Compator.Int.NotGreaterThan(3, 3), PersonalNotificationSeverity.greater_value_error)
                   .ShouldBeTrue(Compator.Int.NotGreaterThan(4, 3), PersonalNotificationSeverity.greater_value_error);                    
            }

            public override void Validate(INotifiableContext notifiableContext)
            {
                new ContextContract(notifiableContext)
                    .ShouldNotBeTrue(Compator.Int.GreaterThan(3,3),PersonalNotificationSeverity.greater_value_error)
                    .ShouldBeTrue(Compator.Int.GreaterThan(3, 3), PersonalNotificationSeverity.greater_value_error);
            }

            public int Inteiro { get; set; }
        }
    }

}
