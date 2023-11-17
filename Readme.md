![GitHub last commit (by committer)](https://img.shields.io/github/last-commit/Cyborg-SB/Notify)
![GitHub License](https://img.shields.io/badge/license-MIT-blue)
![GitHub repo size](https://img.shields.io/github/repo-size/Cyborg-SB/Notify)

# Notifiy

  

Welcome to Notify, your friendly and easy alternative for implementing and using the Notification Pattern in WebApi projects in C# with the NET6.0 framework. If you're looking for a simple and effective way to handle validation messages, errors and notifications, Notify is an option.

#

### Features

- [x] Domain notifications
- [x] Global Scope Filter for response handling



### Prerequisites

To use the library, you must have the Dot [Net6.0](https://dotnet.microsoft.com/en-US/download/dotnet/6.0) SDK version installed in your environment.

## Usage:

Service Registration (Program.cs)

```cs
builder.Services.AddScoped<INotifiableContext, NotifiableContext>();
NotificationMessagesConfiguation.SetupMessagesConfiguration(MovieCreateNotifications.Notifications);
 
```
### Suggestion

To register the set of notifications, you can use a class with static properties to store your notifications and their respective identification codes, for more user-friendly reading.

Notification Codes
```cs
    public static class NotificationCode
    {
        public const long MovieNotFound = 1;
        public const long InvalidMovieIdentifier = 2;
        public const long TitleCantBeNullOrEmpty = 3;
    }
```

Notifications
```cs
public static class MovieCreateNotifications
    {
        public static readonly Dictionary<long, NotificationParameters> Notifications = new()
        {
            {
                NotificationCode.MovieNotFound,
                new NotificationParameters(
                    "Filme não encontrado na base de dados",
                    nameof(MovieCreateRequest.Id),
                    HttpStatusCode.UnprocessableEntity,
                    NotificationSeverity.Warning)
            },
            {
                NotificationCode.CantRemoveUnregisteredMovie,
                new NotificationParameters(
                    "Não é possível remover um filme não cadastrado",
                    nameof(MovieCreateRequest.Id),
                    HttpStatusCode.UnprocessableEntity,
                    NotificationSeverity.Warning)
            },
            {
                NotificationCode.InvalidMovieIdentifier,
                new NotificationParameters(
                    "Identificador informado não é válido",
                    nameof(MovieCreateRequest.Id),
                    HttpStatusCode.UnprocessableEntity,
                    NotificationSeverity.Warning)
            }
        };
    }
```

#
### Filter application in Controllers
Gloabal Scope
```cs
builder.Services.AddControllers(o =>
{
    o.Filters.Add<NotifiableFilter>();
});
```
By Controller
```cs
    [NotifiableFilter]
    [Route("movies")]
    public class MovieController : ControllerBase
    {
        {seu_código_aqui}
    }

```

### Raising Notifications

Entity Validation (Inheriting from EntityBase)
```cs
  public class MovieEntity :  EntityBase, IMovieContract
    {
        public MovieEntity(Guid id, string title, string description, DateTime realeaseDate)
        {
            Id = id;
            Title = title;
            Description = description;
            ReleaseDate = realeaseDate;

            Validate();

        }

        public override void Validate()
        {
            AddNotification("Title should not be null or empty", NotificationCode.TitleCantBeNullOrEmpty, Title);
        }
        ...   

```


Validating by context (INotifiable)
```cs
public class MovieUpdateService : IMovieUpdateService
    {
        public MovieUpdateService(IMovieWriteRepository movieWriteRepository, INotifiableContext notifiable, IMovieGetService movieGetService)
        {
            this.movieWriteRepository = movieWriteRepository;
            this.notifiable = notifiable;
            this.movieGetService = movieGetService;
        }
        private readonly IMovieWriteRepository movieWriteRepository;
        private readonly INotifiableContext notifiable;
        private readonly IMovieGetService movieGetService;

        public async Task<MovieResponse> UpdateMovieAsync(MovieUpdateRequest request)
        {
            try
            {

                var movieToUpdate = await movieGetService.GetMovieAsync(request.Id);

                if (movieToUpdate is null)
                {
                    notifiable.AddNotification(string.Empty, default, request.Id.ToString());
                    return default!;
                }

                if ((DateTime.MinValue.Date == request.ReleaseDate.Date) ||
                   (DateTime.Now.Date < request.ReleaseDate))
                {
                    notifiable.AddNotification(string.Empty, default, request.Id.ToString());
                    return default!;
                }
        ...   

```

Validating by contract 
```cs
        public class MovieCreateService : IMovieCreateService
    {
        public MovieCreateService(IMovieWriteRepository movieWriteRepository, INotifiableContext notifiable, IMovieGetService movieGetService)
        {
            this.movieWriteRepository = movieWriteRepository;
            this.notifiable = notifiable;
            this.movieGetService = movieGetService;
        }
        private readonly IMovieWriteRepository movieWriteRepository;
        private readonly INotifiableContext notifiable;
        private readonly IMovieGetService movieGetService;

        public async Task<MovieResponse> CreateMovieAsync(MovieCreateRequest request)
        {
            try
            {
                var movieToCreate = await movieGetService.GetMovieAsync(request.Id);

                new Contract(notifiable)
                    .ShouldNotBeTrue(movieToCreate is not null, default)
                    .ShouldBeTrue(DateTime.MinValue.Date != request.ReleaseDate.Date, default)
                    .ShouldBeTrue(DateTime.Now.Date <= request.ReleaseDate.Date, default)
                    .ShouldNotBeTrue(string.IsNullOrWhiteSpace(request.Description),default);
        ...   

```
#
### Usage example

This project has a micro api with an in-memory database exemplifying the use of the library.

[Insomnia Example Api Collection](/NotifyApi/Insomnia/NotifyApiExample.json)


## MIT License

Copyright (c) 2023

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
