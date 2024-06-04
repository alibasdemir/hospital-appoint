using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Doctor : User
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string SpecialistLevel { get; set; }
        public int DoctorDepartmentId { get; set; }
        public Department DoctorDepartment { get; set; }
        public int YearsOfExperience { get; set; }
        public string Biography { get; set; }
        public string Qualifications { get; set; }

    }
}
