namespace Application.Features.DoctorAvailabilities.Commands.Create
{
	public class CreateDoctorAvailabilityResponse
	{
		public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
