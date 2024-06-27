using Application.Repositories;
using Domain.Entities;

namespace Application.Services.DoctorAvailabilityService
{
    public class DoctorAvailabilityManager : IDoctorAvailabilityService
	{
		private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;

		public DoctorAvailabilityManager(IDoctorAvailabilityRepository doctorAvailabilityRepository)
		{
			_doctorAvailabilityRepository = doctorAvailabilityRepository;
		}

		public async Task<bool> DoctorAvailabilityValidationById(int id)
		{
			DoctorAvailability? doctorAvailability = await _doctorAvailabilityRepository.GetAsync(x => x.Id == id);
			if (doctorAvailability == null)
			{
				return false;
			}
			return true;
		}
	}
}
