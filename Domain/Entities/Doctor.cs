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
		public virtual User? User { get; set; }
		public virtual Department? Department { get; set; }
		public virtual ICollection<DoctorAvailability> DoctorAvailabilities { get; set; }

        public Doctor()
        {
            DoctorAvailabilities = new HashSet<DoctorAvailability>();
        }

        public Doctor(int id, string specialistLevel, int yearsOfExperience, string biography, int? userId, int? departmentId, Department? department)
            :this() 
        {
            Id = id;
            SpecialistLevel = specialistLevel;
            YearsOfExperience = yearsOfExperience;
            Biography = biography;
            UserId = userId;
            DepartmentId = departmentId;
            Department = department;
        }
    }
}
