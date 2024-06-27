
namespace Application.Features.PatientReports.Commands.Update
{
	public class UpdatePatientReportResponse
	{
		public DateTime AvailableDate { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public int DoctorId { get; set; }
	}
}
