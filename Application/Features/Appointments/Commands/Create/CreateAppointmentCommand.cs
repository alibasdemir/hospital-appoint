using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using static Application.Features.Appointments.Constants.AppointmentsOperationClaims;
using Core.Mailing;
using Application.Features.Appointments.Rules;

namespace Application.Features.Appointments.Commands.Create
{
	public class CreateAppointmentCommand : IRequest<CreateAppointmentResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => [Admin, Write, Add];
        public int PatientId { get; set; }
		public int DoctorAvailabilityId { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, CreateAppointmentResponse>
		{
			private readonly IAppointmentRepository _appointmentRepository;
			private readonly IMapper _mapper;
			private readonly IMailService _mailService;
            private readonly AppointmentBusinessRules _appointmentBusinessRules;

            public CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper, IMailService mailService, AppointmentBusinessRules appointmentBusinessRules)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
                _mailService = mailService;
                _appointmentBusinessRules = appointmentBusinessRules;
            }

            public async Task<CreateAppointmentResponse> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
            {
                await _appointmentBusinessRules.ValidateAppointmentCreation(request);

                Appointment appointment = _mapper.Map<Appointment>(request);
                appointment.Status = AppointmentStatus.Booked;

                await _appointmentRepository.AddAsync(appointment);
                CreateAppointmentResponse response = _mapper.Map<CreateAppointmentResponse>(appointment);

                return response;
            }
		}
	}
}
