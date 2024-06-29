using Application.Repositories;
using Domain.Entities;

namespace Application.Services.DoctorService
{
    public class DoctorManager : IDoctorService
	{
		private readonly IDoctorRepository _doctorRepository;

		public DoctorManager(IDoctorRepository doctorRepository)
		{
			_doctorRepository = doctorRepository;
		}

        public async Task<bool> DoctorValidationById(int id)
		{
			Doctor? doctor = await _doctorRepository.GetAsync(x => x.Id == id);
			if (doctor == null)
			{
				return false;
			}
			return true;
		}

		public async Task<bool> DoctorValidationByPhoneNumber(string phoneNumber)
		{
			Doctor? doctor = await _doctorRepository.GetAsync(x => x.User.PhoneNumber == phoneNumber);
			if (doctor == default)
			{
				return false;
			}
			return true;
		}
        public async Task AddDoctorAsync(Doctor doctor)
        {
            await _doctorRepository.AddAsync(doctor);
        }
    }
}
