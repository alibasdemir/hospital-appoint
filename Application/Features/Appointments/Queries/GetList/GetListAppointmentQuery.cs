using Application.Repositories;
using AutoMapper;
using Core.Paging;
using Core.Requests;
using Core.Responses;
using Domain.Entities;
using MediatR;

namespace Application.Features.Appointments.Queries.GetList
{
    public class GetListAppointmentQuery : IRequest<GetListResponse<GetListAppointmentResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListAppointmentQueryHandler : IRequestHandler<GetListAppointmentQuery, GetListResponse<GetListAppointmentResponse>>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;
            public GetListAppointmentQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListAppointmentResponse>> Handle(GetListAppointmentQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Appointment> appointment = await _appointmentRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                GetListResponse<GetListAppointmentResponse> repsonse = _mapper.Map<GetListResponse<GetListAppointmentResponse>>(appointment);
                return repsonse;
            }
        }
    }
}
