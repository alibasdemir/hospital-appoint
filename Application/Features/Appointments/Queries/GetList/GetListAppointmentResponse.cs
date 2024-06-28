using Domain.Enums;

namespace Application.Features.Appointments.Queries.GetList
{
    public class GetListAppointmentResponse
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorAvailabilityId { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
