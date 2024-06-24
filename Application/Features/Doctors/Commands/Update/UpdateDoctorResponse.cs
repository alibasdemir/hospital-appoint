using Domain.Enums;

namespace Application.Features.Doctors.Commands.Update
{
	public class UpdateDoctorResponse
	{
		public string SpecialistLevel { get; set; }
		public int YearsOfExperience { get; set; }
		public string Biography { get; set; }
		public int UserId { get; set; }
		public int DepartmentId { get; set; }
	}
}
