namespace Application.Features.Notifications.Commands.SoftDelete
{
    public class SoftDeleteNotificationResponse
    {
        public int Id { get; set; }
        public string Detail { get; set; } = "Deletion Successful!";
    }
}
