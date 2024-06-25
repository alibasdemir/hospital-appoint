namespace Application.Features.Doctors.Commands.SoftDelete
{
    public class SoftDeleteDoctorResponse
    {
        public int Id { get; set; }
        public string Detail { get; set; } = "Deletion Successful!";
    }
}
