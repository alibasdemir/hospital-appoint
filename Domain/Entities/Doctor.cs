using Core.DataAccess;

namespace Domain.Entities
{
    public class Doctor : Entity<int>
    {
		public string? SpecialistLevel { get; set; }
		public int? YearsOfExperience { get; set; }
		public string? Biography { get; set; }
		public int? UserId { get; set; }
		public int? DepartmentId { get; set; }
		public virtual User User { get; set; }
		public virtual Department Department { get; set; }
		public virtual ICollection<Appointment> Appointments { get; set; }
		public virtual ICollection<DoctorAvailability> DoctorAvailabilities { get; set; }
		public virtual ICollection<PatientReport> PatientReports { get; set; }
	}
}
