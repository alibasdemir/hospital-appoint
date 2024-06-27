using Application.Repositories;
using Domain.Entities;

namespace Application.Services.AppointmentService
{
    public class AppointmentManager : IAppointmentService
	{
		private readonly IAppointmentRepository _appointmentRepository;

		public AppointmentManager(IAppointmentRepository appointmentRepository)
		{
			_appointmentRepository = appointmentRepository;
		}

		public async Task<bool> AppointmentValidationById(int id)
		{
			Appointment? appointment = await _appointmentRepository.GetAsync(x => x.Id == id);
			if (appointment == null)
			{
				return false;
			}
			return true;
		}
	}
}
