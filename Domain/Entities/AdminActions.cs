using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AdminActions : Entity
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public User Admin { get; set; }
        public AdminActionType ActionType { get; set; }
        public string ActionDescription { get; set; }
    }
    public enum AdminActionType
    {
        UserCreated,
        UserUpdated,
        UserDeleted,
        AppointmentCreated,
        AppointmentUpdated,
        AppointmentDeleted
        // Diğer işlem türleri de test edildikten sonra eklenecek...
    }
}
