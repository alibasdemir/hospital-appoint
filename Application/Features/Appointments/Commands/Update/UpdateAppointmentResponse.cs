using Domain.Enums;

namespace Application.Features.Appointments.Commands.Update
{
    public class UpdateAppointmentResponse
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
