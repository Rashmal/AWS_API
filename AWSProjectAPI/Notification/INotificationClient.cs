namespace AWSProjectAPI.Notification
{
    public interface INotificationClient
    {
        Task NotificationCountGN(int count);
        Task NotificationCountSE(int count);
        Task NotificationCountBF(int count);

    }
}
