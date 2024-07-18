using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Domain.Enums;

namespace Application.Services.AppointmentService
{
    public class AppointmentManager : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentManager(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task DeleteAppointment(int appointmentId)
        {
            var appointment = await _appointmentRepository.GetAsync(a => a.Id == appointmentId);

            if (appointment == null)
            {
                throw new NotFoundException("Appointment not found");
            }

            await _appointmentRepository.DeleteAsync(appointment);
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

        public async Task CreateAppointments(DoctorAvailability doctorAvailability, int intervalInMinutes)
        {
            var startTime = doctorAvailability.StartTime;
            var endTime = doctorAvailability.EndTime;
            var slotDuration = TimeSpan.FromMinutes(intervalInMinutes);

            var appointments = new List<Appointment>();

            while (startTime < endTime)
            {
                if (startTime.TimeOfDay >= TimeSpan.FromHours(12) && startTime.TimeOfDay < TimeSpan.FromHours(13.5))
                {
                    startTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 13, 30, 0);
                }

                var slotEndTime = startTime.Add(slotDuration);
                if (slotEndTime > endTime || (slotEndTime.TimeOfDay > TimeSpan.FromHours(12) && slotEndTime.TimeOfDay <= TimeSpan.FromHours(13.5)))
                {
                    break;
                }

                var appointment = new Appointment
                {
                    StartTime = startTime,
                    EndTime = slotEndTime,
                    Status = AppointmentStatus.Available,
                    PatientId = null,
                    DoctorAvailabilityId = doctorAvailability.Id
                };

                appointments.Add(appointment);
                startTime = slotEndTime;
            }

            foreach (var appointment in appointments)
            {
                await _appointmentRepository.AddAsync(appointment);
            }
        }


    }
}