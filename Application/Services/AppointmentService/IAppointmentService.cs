using Domain.Entities;

namespace Application.Services.AppointmentService
{
	public interface IAppointmentService
	{
		Task<bool> AppointmentValidationById(int id);
		Task<Appointment> AppointmentGetById(int id);
	}
}
