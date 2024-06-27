namespace Application.Services.DoctorAvailabilityService
{
	public interface IDoctorAvailabilityService
	{
		Task<bool> DoctorAvailabilityValidationById(int id);
	}
}
