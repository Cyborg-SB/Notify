![GitHub last commit (by committer)](https://img.shields.io/github/last-commit/Cyborg-SB/Notify)
![GitHub License](https://img.shields.io/badge/license-MIT-blue)
![GitHub repo size](https://img.shields.io/github/repo-size/Cyborg-SB/Notify)

# Notifiy

  

Bem-vindo ao Notify, sua alternativa amigável e descomplicada para implementação e  uso do Notification Pattern em projetos WebApi em C# com o framework NET6.0. Se está a procura de de uma maneira simples e eficaz de lidar com mensagens de validação, erros e notificações, o Notify é uma opção.

#

### Features

- [x] Notificações de domínio
- [x] Filtro de Escopo global para tratamento de resposta



### Pré-requisitos

Par utilizar a biblioteca é necessário que tenha instalando em seu ambiente a versão Dot [Net6.0](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0) SDK.


## Utiliação:

Registro do Serviço (Program.cs)

```cs
builder.Services.AddScoped<INotifiableContext, NotifiableContext>();
NotificationMessagesConfiguation.SetupMessagesConfiguration(MovieCreateNotifications.Notifications);
 
```
### Sugestão

Para registro do conjunto de notificações, pode-se utilizar uma clase com propriedades pripedades estáticas para armazenar sua notificações e seus respectivoo códigos de identificação, para uma leitura mais amigável.

Código identificações
```cs
    public static class NotificationCode
    {
        public const long MovieNotFound = 1;
        public const long InvalidMovieIdentifier = 2;
        public const long TitleCantBeNullOrEmpty = 3;
    }
```

Notificações
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
### Aplicação de filtro em Controllers  
Escopo Global
```cs
builder.Services.AddControllers(o =>
{
    o.Filters.Add<NotifiableFilter>();
});
```
Por Controller
```cs
    [NotifiableFilter]
    [Route("movies")]
    public class MovieController : ControllerBase
    {
        {seu_código_aqui}
    }

```

### Lançando notificações 

Validando entidades (Estendendo EntityBase)
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


Validando diretamente pelo contexto (INotifiable)
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

Validando por meio de um contrato 
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
### Exemplo de Utilização

Este projeto conta com uma micro api com banco de dados em memória exemplificando a utilização da biblioteca.

[Collection Api Exemplo Insomnia](/NotifyApi/Insomnia/NotifyApiExample.json)


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
