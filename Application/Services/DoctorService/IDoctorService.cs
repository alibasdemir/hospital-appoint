using Domain.Entities;

namespace Application.Services.DoctorService
{
	public interface IDoctorService
	{
		Task<bool> DoctorValidationById(int id);
		Task<bool> DoctorValidationByPhoneNumber(string phoneNumber);
		Task AddDoctorAsync(Doctor doctor);
    }
}
