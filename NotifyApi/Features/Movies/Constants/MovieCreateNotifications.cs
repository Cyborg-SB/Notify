using Notify.Entities;
using Notify.Enums;
using System.Net;

namespace NotifyApi.Features.Movies.Constants
{
    public static class MovieCreateNotifications
    {
        public static readonly Dictionary<long, NotificationParameters> Notifications = new()
        {
            {
                10000,
                new NotificationParameters(
                    "Filme não encontrado na base de dados",
                    nameof(MovieCreateRequest.Id),
                    HttpStatusCode.UnprocessableEntity,
                    NotificationSeverity.Warning)
            },
            {
                20000,
                new NotificationParameters(
                    "Não é possível remover um filme não cadastrado",
                    nameof(MovieCreateRequest.Id),
                    HttpStatusCode.UnprocessableEntity,
                    NotificationSeverity.Warning)
            },
            {
                30000,
                new NotificationParameters(
                    "Identificador informado não é válido",
                    nameof(MovieCreateRequest.Id),
                    HttpStatusCode.UnprocessableEntity,
                    NotificationSeverity.Warning)
            }
        };
    }
}
