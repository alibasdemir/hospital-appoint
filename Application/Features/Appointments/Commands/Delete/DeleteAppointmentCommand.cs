using Application.Features.Appointments.Constants;
using Application.Features.Appointments.Rules;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using static Application.Features.Appointments.Constants.AppointmentsOperationClaims;

namespace Application.Features.Appointments.Commands.Delete
{
    public class DeleteAppointmentCommand : IRequest<DeleteAppointmentResponse>, ISecuredRequest, ILoggableRequest
    {
        public string[] RequiredRoles => [Admin, AppointmentsOperationClaims.Delete];
        public int Id { get; set; }

        public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, DeleteAppointmentResponse>
        {
            public readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;
            private readonly AppointmentBusinessRules _appointmentBusinessRules;
            public DeleteAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper, AppointmentBusinessRules appointmentBusinessRules)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
                _appointmentBusinessRules = appointmentBusinessRules;
            }

            public async Task<DeleteAppointmentResponse> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
            {
                Appointment? appointment = await _appointmentRepository.GetAsync(i => i.Id == request.Id);

                await _appointmentBusinessRules.AppointmentShouldBeExist(request.Id);

                await _appointmentRepository.DeleteAsync(appointment);
                DeleteAppointmentResponse response = _mapper.Map<DeleteAppointmentResponse>(appointment);
                return response;
            }
        }
    }
}
