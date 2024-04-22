using Microsoft.AspNetCore.SignalR;

namespace AWSProjectAPI.Notification
{
    public class NotificationHub : Hub <INotificationClient>
    {

        public async Task NotificationCountGN(int count)
        {
            await Clients.All.NotificationCountGN(count);
        }

        public async Task NotificationCountSE(int count)
        {
            await Clients.All.NotificationCountSE(count);
        }

        public async Task NotificationCountBF(int count)
        {
            await Clients.All.NotificationCountBF(count);
        }
    }
}
