using Application.Features.Appointments.Constants;
using Application.Features.Appointments.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using static Application.Features.Appointments.Constants.AppointmentsOperationClaims;

namespace Application.Features.Appointments.Commands.Update
{
    public class UpdateAppointmentCommand : IRequest<UpdateAppointmentResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => [Admin, AppointmentsOperationClaims.Update];
        public int Id { get; set; }
        public int PatientId { get; set; }
		public int DoctorAvailabilityId { get; set; }
		public AppointmentStatus Status { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, UpdateAppointmentResponse>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;
            private readonly AppointmentBusinessRules _appointmentBusinessRules;
            public UpdateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper, AppointmentBusinessRules appointmentBusinessRules)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
                _appointmentBusinessRules = appointmentBusinessRules;
            }

            public async Task<UpdateAppointmentResponse> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
            {
                Appointment? appointment = await _appointmentRepository.GetAsync(i => i.Id == request.Id);

                await _appointmentBusinessRules.AppointmentDeleteControl(request.Id);

                _mapper.Map(request, appointment);

                await _appointmentRepository.UpdateAsync(appointment);
                UpdateAppointmentResponse response = _mapper.Map<UpdateAppointmentResponse>(appointment);
                return response;
            }
        }
    }
}
