using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Notifications : Entity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public NotificationType NotificationType { get; set; }
        public string MessageTitle { get; set; }
        public string MessageContent { get; set; }
        public DateTime SentAt { get; set; }
    }
    public enum NotificationType
    {
        Email,
        SMS
    }

}
