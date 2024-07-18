using Core.DataAccess;
using Domain.Enums;

namespace Domain.Entities
{
    public class Appointment : Entity<int>
    {
        public int? PatientId { get; set; }
        public int? DoctorAvailabilityId { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Patient? Patient { get; set; }
        public virtual DoctorAvailability? DoctorAvailability { get; set; }
        public virtual ICollection<PatientReport>? PatientReports { get; set; }

        public Appointment()
        {
            PatientReports = new HashSet<PatientReport>();
        }

        public Appointment(int id, int? patientId, int? doctorAvailabilityId, AppointmentStatus status, DateTime startTime, DateTime endTime, Patient? patient)
            : base(id)
        {
            PatientId = patientId;
            DoctorAvailabilityId = doctorAvailabilityId;
            Status = status;
            StartTime = startTime;
            EndTime = endTime;
            Patient = patient;
        }
    }
}