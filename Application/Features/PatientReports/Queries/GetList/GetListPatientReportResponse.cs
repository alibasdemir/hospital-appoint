namespace Application.Features.PatientReports.Queries.GetList
{
    public class GetListPatientReportResponse
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
