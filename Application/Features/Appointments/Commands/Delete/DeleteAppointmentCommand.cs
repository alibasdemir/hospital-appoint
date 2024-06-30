using Application.Features.Appointments.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
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
            public DeleteAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
            }

            public async Task<DeleteAppointmentResponse> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
            {
                Appointment? appointment = await _appointmentRepository.GetAsync(i => i.Id == request.Id);

                if (appointment == null)
                {
                    throw new NotFoundException(AppointmentsMessages.AppointmentNotExists);
                }

                await _appointmentRepository.DeleteAsync(appointment);
                DeleteAppointmentResponse response = _mapper.Map<DeleteAppointmentResponse>(appointment);
                return response;
            }
        }
    }
}
