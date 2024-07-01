
namespace Application.Features.PatientReports.Commands.Create
{
	public class CreatePatientReportResponse
	{
		public int Id { get; set; }
		public int AppointmentId { get; set; }
		public string Title { get; set; }
		public string Details { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
