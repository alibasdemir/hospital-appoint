using Domain.Entities;

namespace Application.Services.PatientService
{
	public interface IPatientService
	{
		Task<bool> PatientValidationById(int id);
        Task AddPatientAsync(Patient patient);
		Task<User> GetUserAsync(int patientId);
		Task<Patient> PatientGetByUserId(int userId);
        Task UpdatePatientAsync(Patient patient);


    }
}
