using Core.DataAccess;
using Domain.Enums;

namespace Domain.Entities
{
    public class Appointment : Entity<int>
    {
        public int PatientId { get; set; }
        public int DoctorAvailabilityId { get; set; }
        public int PatientReportId { get; set; }
        public AppointmentStatus Status { get; set; }

        public Patient Patient { get; set; }
        public DoctorAvailability DoctorAvailability { get; set; }
        public PatientReport PatientReport { get; set; }
    }
}
