using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Doctor : User
    {
        public string SpecialistLevel { get; set; }
        public int YearsOfExperience { get; set; }
        public string Biography { get; set; }
        public string Qualifications { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<DoctorAvailability> DoctorAvailabilities { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<PatientReport> PatientReports { get; set; }
    }
}
