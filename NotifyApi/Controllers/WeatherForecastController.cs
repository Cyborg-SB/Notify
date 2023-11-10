using Microsoft.AspNetCore.Mvc;
using Notify.Interfaces;
using static NotifyConsole.PersonalNotification;

namespace NotifyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get([FromServices] INotifiableContext notifiableContext, [FromServices] ICustomSeviceXPTo xpto)
        {

            var x2 = new BaseEntity();

            x2.Validate(notifiableContext);

            x2.Validate();

            xpto.NotifyTest();
            notifiableContext.AddNotification(string.Empty, PersonalNotificationSeverity.failed_to_retrieve_response);

            xpto.NotifyTest();
            notifiableContext.AddNotification(string.Empty, PersonalNotificationSeverity.failed_to_retrieve_response);
            notifiableContext.AddNotification(string.Empty, PersonalNotificationSeverity.failed_to_retrieve_response);
            xpto.NotifyTest();
            notifiableContext.AddNotifications(x2.Notifications);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
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

