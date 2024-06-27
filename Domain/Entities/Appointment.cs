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
		public Patient Patient { get; set; }
		public virtual DoctorAvailability DoctorAvailability { get; set; }
		public virtual PatientReport PatientReport { get; set; }
	}
}
