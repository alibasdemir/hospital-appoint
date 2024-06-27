using Core.DataAccess;
using Domain.Enums;

namespace Domain.Entities
{
    public class Patient : Entity<int>
    {
		public BloodType BloodType { get; set; }
		public InsuranceType InsuranceType { get; set; }
		public string SocialSecurityNumber { get; set; }
		public string? HealthHistory { get; set; }
		public string? Allergies { get; set; }
		public string? CurrentMedications { get; set; }
		public string? EmergencyContactName { get; set; }
		public string? EmergencyContactPhoneNumber { get; set; }
		public string? EmergencyContactRelationship { get; set; }
		public int? UserId { get; set; }
		public virtual User User { get; set; }
		public virtual ICollection<Appointment> Appointments { get; set; }
		public virtual ICollection<PatientReport> PatientReports { get; set; }
	}
}
