namespace Application.Services.AppointmentService
{
	public interface IAppointmentService
	{
		Task<bool> AppointmentValidationById(int id);
	}
}
