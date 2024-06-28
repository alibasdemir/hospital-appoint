using Core.DataAccess;

namespace Domain.Entities
{
    public class PatientReport : Entity<int>
    {
        public int? AppointmentId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public virtual Appointment? Appointment { get; set; }

        public PatientReport()
        { 
        }

        public PatientReport(
            int id, int? appointmentId, string title, string details) 
            : base(id)
        {
            AppointmentId = appointmentId;
            Title = title;
            Details = details;
        }
    }
}
