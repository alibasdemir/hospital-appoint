using Core.DataAccess;

namespace Domain.Entities
{
    public class PatientReport : Entity<int>
    {
        public int AppointmentId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
