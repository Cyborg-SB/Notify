using Notify;
using Notify.Entities;
using Notify.Enums;
using Notify.Services.Interfaces;
using Notify.Validators;
using System.Net;

namespace NotifyApi
{
    public static class PersonalNotification
    {
        public static readonly Dictionary<long, NotificationParameters> myNotifications = new()
        {
            { 
                NotificationCode.failed_to_retrieve_response, 
                new NotificationParameters(
                    "Erro ao recuperar resposta do serviço XPTO 1", 
                    string.Empty,  
                    HttpStatusCode.InternalServerError, 
                    NotificationSeverity.Fatal) 
            },
            { 
                NotificationCode.greater_value_error, 
                new NotificationParameters(
                    "O Valor não deve ser maior que 3", 
                    nameof(BaseEntity.Inteiro),
                    HttpStatusCode.UnprocessableEntity, 
                    NotificationSeverity.Warning) 
            }
        };

        public static readonly Dictionary<long, NotificationParameters> myNotifications2 = new()
        {
            { 
                NotificationCode.warning_to_retrieve_response, 
                new NotificationParameters(
                    "Erro ao recuperar resposta do serviço XPTO 2", 
                    string.Empty, 
                    HttpStatusCode.InternalServerError, 
                    NotificationSeverity.Error) 
            },
            { 
                NotificationCode.warning_greater_value_error, 
                new NotificationParameters(
                    "O Valor não deve ser maior que 3", 
                    string.Empty, 
                    HttpStatusCode.UnprocessableEntity, 
                    NotificationSeverity.Warning) 
            }
        };

        public static class NotificationCode
        {
            public const long failed_to_retrieve_response = 10000000;
            public const long greater_value_error = 10000002;    
            public const long warning_to_retrieve_response = 10000001;
            public const long warning_greater_value_error = 10000003;
        }

        public class BaseEntity : EntityBase
        {
            public BaseEntity()
            {
                new Contract(this)
                   .ShouldBeTrue(Compator.Int.NotGreaterThan(3, 3), NotificationCode.greater_value_error)
                   .ShouldBeTrue(Compator.Int.NotGreaterThan(4, 3), NotificationCode.greater_value_error);
            }

            public override void Validate(INotifiableContext notifiableContext)
            {
                AddNotification(string.Empty, NotificationCode.greater_value_error, Inteiro.ToString());


                new ContextContract(notifiableContext)
                    .ShouldNotBeTrue(Compator.Int.GreaterThan(3, 3), NotificationCode.greater_value_error)
                    .ShouldBeTrue(Compator.Int.GreaterThan(3, 3), NotificationCode.greater_value_error);

            }
            public int Inteiro { get; set; }
        }
    }

}
