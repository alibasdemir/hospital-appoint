using Application.Features.Appointments.Constants;
using Application.Features.Appointments.Rules;
using Application.Repositories;
using AutoMapper;
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
            private readonly AppointmentBusinessRules _appointmentBusinessRules;

            public GetByIdAppointmentQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper, AppointmentBusinessRules appointmentBusinessRules)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
                _appointmentBusinessRules = appointmentBusinessRules;
            }

            public async Task<GetByIdAppointmentResponse> Handle(GetByIdAppointmentQuery request, CancellationToken cancellationToken)
            {
                Appointment? appointment = await _appointmentRepository.GetAsync(i => i.Id == request.Id);

                await _appointmentBusinessRules.AppointmentDeleteControl(request.Id);

                GetByIdAppointmentResponse response = _mapper.Map<GetByIdAppointmentResponse>(appointment);
                return response;
            }
        }
    }
}
