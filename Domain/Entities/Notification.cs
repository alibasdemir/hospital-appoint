using Core.DataAccess;
using Domain.Enums;

namespace Domain.Entities
{
    public class Notification : Entity<int>     // srs
    {
        public NotificationType Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }

    }
}
