namespace Application.Features.DoctorAvailabilities.Commands.SoftDelete
{
    public class SoftDeleteDoctorAvailabilityResponse
    {
        public int Id { get; set; }
        public string Detail { get; set; } = "Deletion Successful!";
    }
}
