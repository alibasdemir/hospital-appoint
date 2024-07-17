using Domain.Entities;

namespace Application.Services.AppointmentService
{
	public interface IAppointmentService
	{
        Task<bool> AppointmentValidationById(int id);
        Task CreateAppointments(DoctorAvailability doctorAvailability, int intervalInMinutes);
        Task DeleteAppointment(int appointmentId);
    }
}
