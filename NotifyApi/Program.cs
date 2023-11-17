using Notify.Filters;
using Notify.Services;
using Notify.Services.Interfaces;
using NotifyApi.Features.Movies.Constants;
using NotifyApi.Features.Movies.Repositories;
using NotifyApi.Features.MoviesFeatures;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(o =>
{
    o.Filters.Add<NotifiableFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<INotifiableContext, NotifiableContext>();
NotificationMessagesConfiguation.SetupMessagesConfiguration(MovieCreateNotifications.Notifications);

//Repositories
builder.Services.AddSingleton<IMovieReadRepository,MovieReadRepository>();
builder.Services.AddSingleton<IMovieWriteRepository,MovieWriteRepository>();

//Services
builder.Services.AddTransient<IMovieDeleteService, MovieDeleteService>();
builder.Services.AddTransient<IMovieGetService, MovieGetService>();
builder.Services.AddTransient<IMovieCreateService, MovieCreateService>();
builder.Services.AddTransient<IMovieReplaceService, MovieReplaecService>();
builder.Services.AddTransient<IMovieUpdateService, MovieUpdateService>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
