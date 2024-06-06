using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Patient : User
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string BloodType { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string HealthHistory { get; set; }
        public string Allergies { get; set; }
        public string CurrentMedications { get; set; }
        public string EmergencyContactName { get; set; } 
        public string EmergencyContactPhoneNumber { get; set; } 
        public string EmergencyContactRelationship { get; set; }
        public bool HasInsurance { get; set; }
        public string InsuranceType { get; set; }

        public ICollection<Appointments> Appointments { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<PatientReports> PatientReports { get; set; }
    }
}
