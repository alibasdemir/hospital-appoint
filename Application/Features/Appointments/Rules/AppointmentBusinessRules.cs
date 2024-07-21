using Application.Repositories;
using Application.Services.DoctorAvailabilityService;
using Application.Services.PatientService;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Application.Features.Patients.Constants;
using Application.Features.DoctorAvailabilities.Constants;
using Application.Features.Appointments.Commands.Create;
using Application.Features.Appointments.Constants;
using Domain.Entities;

namespace Application.Features.Appointments.Rules
{
    public class AppointmentBusinessRules
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientService _patientService;
        private readonly IDoctorAvailabilityService _doctorAvailabilityService;
        private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;

        public AppointmentBusinessRules(
            IAppointmentRepository appointmentRepository,
            IPatientService patientService,
            IDoctorAvailabilityService doctorAvailabilityService,
            IDoctorAvailabilityRepository doctorAvailabilityRepository)
        {
            _appointmentRepository = appointmentRepository;
            _patientService = patientService;
            _doctorAvailabilityService = doctorAvailabilityService;
            _doctorAvailabilityRepository = doctorAvailabilityRepository;
        }

        public async Task ValidateAppointmentCreation(CreateAppointmentCommand request)
        {
            bool isPatientExist = await _patientService.PatientValidationById(request.PatientId);
            bool isDoctorAvailabilityExist = await _doctorAvailabilityService.DoctorAvailabilityValidationById(request.DoctorAvailabilityId);
            var doctorAvailability = await _doctorAvailabilityRepository.GetAsync(i => i.Id == request.DoctorAvailabilityId);

            if (!isPatientExist)
                throw new NotFoundException(PatientsMessages.PatientNotExists);

            if (!isDoctorAvailabilityExist)
                throw new NotFoundException(DoctorAvailabilityMessages.DoctorAvailabilityNotExists);

            if (request.StartTime < doctorAvailability.StartTime || request.EndTime > doctorAvailability.EndTime)
            {
                throw new BusinessException(AppointmentsMessages.OutsideTimeSlot);
            }

            var conflictingAppointment = _appointmentRepository.GetList()
                .Items
                .FirstOrDefault(a => a.DoctorAvailabilityId == request.DoctorAvailabilityId && a.StartTime < request.EndTime && a.EndTime > request.StartTime);

            if (conflictingAppointment != null)
                throw new BusinessException(DoctorAvailabilityMessages.TimeSlotAlreadyBooked);
        }

        public async Task AppointmentShouldBeExist(int id)
        {
            Appointment? appointment = await _appointmentRepository.GetAsync(i => i.Id == id);
            if (appointment == null)
            {
                throw new BusinessException(AppointmentsMessages.AppointmentNotExists);
            }
        }

        public async Task AppointmentDeleteControl(int id)
        {
            Appointment? appointment = await _appointmentRepository.GetAsync(i => i.Id == id);
            if (appointment == null || appointment.IsDeleted == true)
            {
                throw new BusinessException(AppointmentsMessages.AppointmentNotExists);
            }
        }
    }
}
