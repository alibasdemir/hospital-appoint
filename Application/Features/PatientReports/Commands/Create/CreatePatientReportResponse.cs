
namespace Application.Features.PatientReports.Commands.Create
{
	public class CreatePatientReportResponse
	{
		public int AppointmentId { get; set; }
		public string Title { get; set; }
		public string Details { get; set; }
	}
}
