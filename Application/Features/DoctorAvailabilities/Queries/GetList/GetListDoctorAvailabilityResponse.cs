namespace Application.Features.DoctorAvailabilities.Queries.GetList
{
    public class GetListDoctorAvailabilityResponse
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
