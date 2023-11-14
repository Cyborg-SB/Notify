using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Notify.Dtos;
using Notify.Entities;
using Notify.Enums;
using Notify.Services;
using Notify.Services.Interfaces;
using System.Net;

namespace Notify.Extensions
{
    internal class NotifiableFilterExtensions
    {

        internal static async Task NotifiableFilterProcessAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var notifiable = GetNotifiableContext(context);

            if (notifiable.Invalid)
            {
                var response = GetNotifiableResultReponseMessages(notifiable.Notifications);

                context.HttpContext.Response.StatusCode = response.StatusCode;
                context.HttpContext.Response.ContentType = "application/json";
                await context.HttpContext.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new ObjectResult(response)?.Value));
                return;
            }       
            await next.Invoke();
        }

        private static INotifiableContext GetNotifiableContext(FilterContext filterContext) =>
            filterContext.HttpContext.RequestServices.GetRequiredService<INotifiableContext>();


        private static NotifiableResultReponse GetNotifiableResultReponseMessages(IReadOnlyCollection<NotificationItem> notificationItems)
        {
            var lstNotificationMessgeResult = new List<NotificationMessageResult>(notificationItems.Count);

            var messageConfig = NotificationMessagesConfiguation.Instance!.MessagesConfiguation;

            var enumerator = notificationItems.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                messageConfig.TryGetValue(current.Key, out NotificationParameters? value);
                lstNotificationMessgeResult.Add(
                    new NotificationMessageResult(
                        current.Message,
                        current.Key,
                        value?.PropertyName ?? "",
                        current.PropertyValue,
                        value?.NotificationSeverity ?? NotificationSeverity.Warning,
                        value?.StatusCode ?? HttpStatusCode.BadRequest
                    )); ;
            }

            var maxSeverityElement = lstNotificationMessgeResult.Select(x => x).MaxBy(y => y.Severity);
            var resp = new NotifiableResultReponse((int)maxSeverityElement!.StatusCode,
                Enum.GetName(typeof(HttpStatusCode), maxSeverityElement!.StatusCode)!,
                lstNotificationMessgeResult);
            return resp;
        }
    }
}
