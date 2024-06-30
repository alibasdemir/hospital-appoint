namespace Application.Features.Notifications.Commands.Delete
{
    public class DeleteNotificationResponse
    {
        public int Id { get; set; }
        public string Detail { get; set; } = "Deletion Successful!";
    }
}
