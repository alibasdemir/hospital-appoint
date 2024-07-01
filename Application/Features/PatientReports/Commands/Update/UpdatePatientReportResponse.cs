
namespace Application.Features.PatientReports.Commands.Update
{
	public class UpdatePatientReportResponse
	{
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
