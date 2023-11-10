using Notify;
using Notify.Entities;
using Notify.Interfaces;
using System.Net;

namespace NotifyConsole
{
    public static class PersonalNotification
    {
        public static readonly Dictionary<long, NotificationParameters> myNotifications = new()
        {
            { PersonalNotificationSeverity.failed_to_retrieve_response, new NotificationParameters("Erro ao recuperar responsa do serviço XPTO", string.Empty, HttpStatusCode.InternalServerError, NotificationSeverity.Error) },
            { PersonalNotificationSeverity.greater_value_error, new NotificationParameters("O Valor não deve ser maior", string.Empty, HttpStatusCode.InternalServerError, NotificationSeverity.Error) }
        };

        public static readonly Dictionary<long, NotificationParameters> myNotifications2 = new()
        {
            { PersonalNotificationSeverity.warning_to_retrieve_response, new NotificationParameters("Erro ao recuperar responsa do serviço XPTO", string.Empty, HttpStatusCode.InternalServerError, NotificationSeverity.Error) },
            { PersonalNotificationSeverity.warning_greater_value_error, new NotificationParameters("O Valor não deve ser maior", string.Empty, HttpStatusCode.InternalServerError, NotificationSeverity.Error) }
        };

        public static class PersonalNotificationSeverity
        {
            public const  long failed_to_retrieve_response = 10000000;
            public const long greater_value_error = 10000002;    
            public const long warning_to_retrieve_response = 10000001;
            public const long warning_greater_value_error = 10000003;
        }

        public class BaseEntity : EntityBase
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
        }
    }

}
