using Notify;
using Notify.Filters;
using Notify.Interfaces;
using NotifyApi.Controllers;
using NotifyConsole;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(o =>
{
    //o.Filters.Add<NotifiableFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICustomSeviceXPTo, CustomSeviceXPTo>();
builder.Services.AddScoped<INotifiableContext, NotifiableContext>();
NotificationMessagesConfiguation.SetupMessagesConfiguration(new[] { PersonalNotification.myNotifications, PersonalNotification.myNotifications2 });

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
