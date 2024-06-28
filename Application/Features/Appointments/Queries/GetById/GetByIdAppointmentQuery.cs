using Application.Features.Appointments.Constants;
using Application.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.Appointments.Queries.GetById
{
    public class GetByIdAppointmentQuery : IRequest<GetByIdAppointmentResponse>
    {
        public int Id { get; set; }

        public class GetByIdAppointmentQueryHandler : IRequestHandler<GetByIdAppointmentQuery, GetByIdAppointmentResponse>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;

            public GetByIdAppointmentQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdAppointmentResponse> Handle(GetByIdAppointmentQuery request, CancellationToken cancellationToken)
            {
                Appointment? appointment = await _appointmentRepository.GetAsync(i => i.Id == request.Id);

                if (appointment == null || appointment.IsDeleted == true) 
                {
                    throw new NotFoundException(AppointmentsMessages.AppointmentNotExists);
                }

                GetByIdAppointmentResponse response = _mapper.Map<GetByIdAppointmentResponse>(appointment);
                return response;
            }
        }
    }
}
