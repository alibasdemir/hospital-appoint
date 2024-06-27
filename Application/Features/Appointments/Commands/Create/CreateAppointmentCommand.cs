using Application.Repositories;
using Application.Services.DoctorAvailabilityService;
using Application.Services.PatientService;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Domain.Enums;
using MediatR;

using Application.Features.Patients.Constants;
using Application.Features.DoctorAvailabilities.Constants;
using Application.Features.Appointments.Constants;

namespace Application.Features.Appointments.Commands.Create
{
	public class CreateAppointmentCommand : IRequest<CreateAppointmentResponse>
	{
		public int PatientId { get; set; }
		public int DoctorAvailabilityId { get; set; }
		public AppointmentStatus Status { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, CreateAppointmentResponse>
		{
			private readonly IAppointmentRepository _appointmentRepository;
			private readonly IMapper _mapper;
			private readonly IPatientService _patientService;
			private readonly IDoctorAvailabilityService _doctorAvailabilityService;

			public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper, IPatientService patientService, IDoctorAvailabilityService doctorAvailabilityService)
			{
				_appointmentRepository = appointmentRepository;
				_mapper = mapper;
				_patientService = patientService;
				_doctorAvailabilityService = doctorAvailabilityService;
			}

			public async Task<CreateAppointmentResponse> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
			{
				bool isPatientExist = await _patientService.PatientValidationById(request.PatientId);
				bool isDoctorAvailabilityExist = await _doctorAvailabilityService.DoctorAvailabilityValidationById(request.DoctorAvailabilityId);
				
				Appointment appointment = _mapper.Map<Appointment>(request);

				if (appointment.StartTime != request.StartTime)
					throw new NotFoundException(AppointmentsMessages.AppointmentNotExists);

				else if (isPatientExist && isDoctorAvailabilityExist && appointment.StartTime == request.StartTime)
				{
					await _appointmentRepository.AddAsync(appointment);
					CreateAppointmentResponse response = _mapper.Map<CreateAppointmentResponse>(appointment);
					return response;
				}

				else if (!isPatientExist && isDoctorAvailabilityExist)
					throw new NotFoundException(PatientsMessages.PatientNotExists);

				else if (!isDoctorAvailabilityExist && isPatientExist)
					throw new NotFoundException(DoctorAvailabilityMessages.DoctorAvailabilityNotExists);

				else
					throw new NotFoundException("Doctor Availability and Patient not exist.");
			}
		}
	}
}
