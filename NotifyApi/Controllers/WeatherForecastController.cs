using Microsoft.AspNetCore.Mvc;
using Notify.Attributes;
using Notify.Dtos;
using Notify.Filters;
using Notify.Interfaces;
using static NotifyConsole.PersonalNotification;

namespace NotifyApi.Controllers
{
    [NotifiableFilter]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly INotifiableContext notifiableContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, INotifiableContext notifiableContext)
        {
            _logger = logger;
            this.notifiableContext = notifiableContext;
        }

        [HttpPost(Name = "GetWeatherForecast")]
        [ProducesResponseType(200, Type = typeof(NotifiableResultReponse))]
        [ProducesResponseType(400, Type = typeof(NotifiableResultReponse))]
        [ProducesResponseType(500,Type = typeof(NotifiableResultReponse))]
        public IActionResult Get([FromServices] INotifiableContext notifiableContext, [FromServices] ICustomSeviceXPTo xpto, BaseEntity xpto2)
        {

            var x2 = new BaseEntity
            {
                Inteiro = 20
            };

            x2.Validate(notifiableContext);
            x2.Validate();
            

            xpto.NotifyTest();
            notifiableContext.AddNotification(string.Empty, NotificationCode.failed_to_retrieve_response, x2.Inteiro.ToString());

            xpto.NotifyTest();
            notifiableContext.AddNotification(string.Empty, NotificationCode.failed_to_retrieve_response);
            notifiableContext.AddNotification(string.Empty, NotificationCode.failed_to_retrieve_response);
            xpto.NotifyTest();
            notifiableContext.AddNotifications(x2.Notifications);

            return Ok( Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray());
        }
    }

    public class CustomSeviceXPTo : ICustomSeviceXPTo
    {
        private readonly INotifiableContext notifiableContext;
        public CustomSeviceXPTo(INotifiableContext notifiableContext)
        {
            this.notifiableContext = notifiableContext;
        }
        public void NotifyTest()
        {
            if (notifiableContext.Invalid)
                Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(notifiableContext.Notifications));
        }
    }

    public interface ICustomSeviceXPTo
    {
        public void NotifyTest();
    }
}

