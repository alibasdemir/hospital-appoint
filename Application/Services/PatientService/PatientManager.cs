using Application.Repositories;
using Domain.Entities;

namespace Application.Services.PatientService
{
	public class PatientManager : IPatientService
	{
		private readonly IPatientRepository _patientRepository;
		public PatientManager(IPatientRepository patientRepository)
		{
			_patientRepository = patientRepository;
		}

        public async Task<bool> PatientValidationById(int id)
		{
			Patient? patient = await _patientRepository.GetAsync(x => x.Id == id);
			if (patient == null)
			{
				return false;
			}
			return true;
		}

        public async Task AddPatientAsync(Patient patient)
        {
            await _patientRepository.AddAsync(patient);
        }
		public async Task<User> GetUserAsync(int patientId)
		{
			return await _patientRepository.GetUserAsync(patientId);
		}
	}
}
