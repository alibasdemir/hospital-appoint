using Application.Features.Appointments.Constants;
using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.Appointments.Commands.SoftDelete
{
    public class SoftDeleteAppointmentCommand : IRequest<SoftDeleteAppointmentResponse>
    {

        public int Id { get; set; }


        public class SoftDeleteAppointmentCommandHandler : IRequestHandler<SoftDeleteAppointmentCommand, SoftDeleteAppointmentResponse>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;

            public SoftDeleteAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
            }

            public async Task<SoftDeleteAppointmentResponse> Handle(SoftDeleteAppointmentCommand request, CancellationToken cancellationToken)
            {
                Appointment? appointment = await _appointmentRepository.GetAsync(i => i.Id == request.Id);

                if (appointment == null)
                {
                    throw new NotFoundException(AppointmentsMessages.AppointmentNotExists);
                }
                
                await _appointmentRepository.SoftDeleteAsync(appointment);

                SoftDeleteAppointmentResponse response = _mapper.Map<SoftDeleteAppointmentResponse>(appointment);
                return response;
            }
        }
    }
}
