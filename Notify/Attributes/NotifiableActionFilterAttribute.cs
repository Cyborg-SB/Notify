using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Notify.Dtos;
using Notify.Interfaces;
using System.Net;
using System.Text;

namespace Notify.Attributes
{
    public class NotifiableActionFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext context) 
        { 
            var notifiable = GetNotifiableContext(context);

            if (notifiable.Valid)
                return;

            var messageConfig = NotificationMessagesConfiguation.Instance!.MessagesConfiguation;

            context.Result = new ContentResult()
            {
                ContentType = "application/json",
                Content = System.Text.Json.JsonSerializer.Serialize(new NotifiableResultReponse(500, nameof(HttpStatusCode.UnprocessableEntity), notifiable.Notifications)),
                StatusCode = context.HttpContext.Response.StatusCode,
            };

        }

        private INotifiableContext GetNotifiableContext(FilterContext filterContext) =>
            filterContext.HttpContext.RequestServices.GetRequiredService<INotifiableContext>();


        private int GetNotificationMaxSeverity()
        {
            return 0;
        }

    }
}
