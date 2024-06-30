namespace Application.Features.Patients.Commands.SoftDelete
{
    public class SoftDeletePatientResponse
    {
        public int Id { get; set; }
        public string Detail { get; set; } = "Deletion Successful!";
    }
}
