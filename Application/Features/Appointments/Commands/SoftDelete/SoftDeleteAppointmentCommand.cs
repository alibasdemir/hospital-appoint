using Application.Features.Appointments.Constants;
using Application.Features.Appointments.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Appointments.Constants.AppointmentsOperationClaims;

namespace Application.Features.Appointments.Commands.SoftDelete
{
    public class SoftDeleteAppointmentCommand : IRequest<SoftDeleteAppointmentResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => [Admin, AppointmentsOperationClaims.Delete];
        public int Id { get; set; }

        public class SoftDeleteAppointmentCommandHandler : IRequestHandler<SoftDeleteAppointmentCommand, SoftDeleteAppointmentResponse>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;
            private readonly AppointmentBusinessRules _appointmentBusinessRules;

            public SoftDeleteAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper, AppointmentBusinessRules appointmentBusinessRules)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
                _appointmentBusinessRules = appointmentBusinessRules;
            }

            public async Task<SoftDeleteAppointmentResponse> Handle(SoftDeleteAppointmentCommand request, CancellationToken cancellationToken)
            {
                Appointment? appointment = await _appointmentRepository.GetAsync(i => i.Id == request.Id);

                await _appointmentBusinessRules.AppointmentDeleteControl(request.Id);
                
                await _appointmentRepository.SoftDeleteAsync(appointment);

                SoftDeleteAppointmentResponse response = _mapper.Map<SoftDeleteAppointmentResponse>(appointment);
                return response;
            }
        }
    }
}
