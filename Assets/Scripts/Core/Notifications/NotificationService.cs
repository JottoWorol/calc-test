using Core.Infrastructure;
using Unity.Notifications.Android;

namespace Core.Notifications
{
    public class NotificationService : IStartable
    {
        private const string ChannelID = "calculator_channel";
        private const string ChannelName = "Default Channel";

        public void SendNotification(string title, string text)
        {
            var notification = new AndroidNotification
            {
                Title = title,
                Text = text,
                FireTime = System.DateTime.Now,
            };

            AndroidNotificationCenter.SendNotification(notification, ChannelID);
        }

        public void OnStart()
        {
            var channel = new AndroidNotificationChannel()
            {
                Id = ChannelID,
                Name = ChannelName,
                Importance = Importance.High,
                Description = "Generic notifications",
            };
            AndroidNotificationCenter.RegisterNotificationChannel(channel);
        }
    }
}