using Domain.Enums;

namespace Application.Features.Appointments.Commands.Update
{
    public class UpdateAppointmentResponse
    {
		public int PatientId { get; set; }
		public int DoctorAvailabilityId { get; set; }
		public AppointmentStatus Status { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
	}
}
