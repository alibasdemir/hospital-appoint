namespace Application.Features.DoctorAvailabilities.Queries.GetById
{
    public class GetByIdDoctorAvailabilityResponse
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
