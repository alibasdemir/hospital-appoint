namespace Application.Features.PatientReports.Commands.SoftDelete
{
    public class SoftDeletePatientReportResponse
    {
        public int Id { get; set; }
        public string Detail { get; set; } = "Deletion Successful!";
    }
}
