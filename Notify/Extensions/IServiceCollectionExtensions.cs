using Microsoft.Extensions.DependencyInjection;
using Notify.Entities;
using Notify.Services;
using Notify.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Notify.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class IServiceCollectionExtensions
    {
        public static void RegisterNotificationMessagesService(this IServiceCollection services, IDictionary<long, NotificationParameters> notificationParameters) =>
            services.AddSingleton<INotificationMessagesConfiguation>(new NotificationMessagesConfiguation(notificationParameters));
        
        public static void RegisterNotificationMessagesService(this IServiceCollection services, IDictionary<long, NotificationParameters>[] notificationParameters) =>
            services.AddSingleton<INotificationMessagesConfiguation>(new NotificationMessagesConfiguation(notificationParameters));

        
    }
}
