﻿using Notify.Entities;
using Notify.Enums;
using Notify.Services;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Notify.Tests.Shared
{
    [ExcludeFromCodeCoverage]
    public static class Common
    {    

        public static readonly Dictionary<long, NotificationParameters> notificationParamertersSetup = new()
            {
                { 1,
                    new NotificationParameters(
                        nameof(NotificationMessagesConfigurationTests),
                        nameof(notificationParamertersSetup),
                        HttpStatusCode.UnprocessableEntity,
                        NotificationSeverity.Warning) }
            };

        public static readonly Dictionary<long, NotificationParameters> noticationParamertersSetup2 = new()
            {
                { 2,
                    new NotificationParameters(
                        nameof(NotificationMessagesConfigurationTests),
                        nameof(notificationParamertersSetup),
                        HttpStatusCode.UnprocessableEntity,
                        NotificationSeverity.Warning) }
            };

    }
}
