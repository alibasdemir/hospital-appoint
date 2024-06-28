using Domain.Enums;

namespace Application.Features.Patients.Queries.GetById
{
    public class GetByIdPatientResponse
    {
        public int Id { get; set; }
        public BloodType BloodType { get; set; }
        public InsuranceType InsuranceType { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string HealthHistory { get; set; }
        public string Allergies { get; set; }
        public string CurrentMedications { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
