using Domain.Enums;

namespace Application.Features.Notifications.Queries.GetById
{
    public class GetByIdNotificationResponse
    {
        public int Id { get; set; }
        public NotificationType NotificationType { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
