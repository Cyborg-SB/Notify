// See https://aka.ms/new-console-template for more information
using Notify;
using NotifyConsole;
using static NotifyConsole.PersonalNotification;

Console.WriteLine("Hello, World!");


NotificationMessagesConfiguation.SetupMessagesConfiguration(PersonalNotification.myNotifications);

var x2 = new BaseEntity();



Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(x2.Notifications));
Console.ReadLine();