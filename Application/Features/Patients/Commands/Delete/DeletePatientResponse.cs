namespace Application.Features.Patients.Commands.Delete
{
    public class DeletePatientResponse
    {
        public int Id { get; set; }
        public string Detail { get; set; } = "Deletion Successful!";
    }
}
