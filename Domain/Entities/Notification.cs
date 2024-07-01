using Core.DataAccess;
using Domain.Enums;

namespace Domain.Entities
{
    public class Notification : Entity<int>
    {
        public NotificationType NotificationType { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }

        public Notification()
        {
        }

        public Notification(int id, NotificationType notificationType, string title, string message, DateTime sentAt) 
            : base(id)
        {
            Id = id;
            NotificationType = notificationType;
            Title = title;
            Message = message;
            SentAt = sentAt;
        }
    }
}
