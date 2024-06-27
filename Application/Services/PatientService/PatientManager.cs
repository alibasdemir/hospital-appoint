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
	}
}
