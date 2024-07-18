using Application.Repositories;
using AutoMapper;
using Core.Paging;
using Core.Requests;
using Core.Responses;
using Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace Application.Features.Appointments.Queries.GetByPatient
{
    public class GetAppointmentsByPatientQuery : IRequest<GetListResponse<GetAppointmentsByPatientResponse>>
    {
        public PageRequest PageRequest { get; set; }
        public int PatientId { get; set; }

        public class GetAppointmentsByPatientQueryHandler : IRequestHandler<GetAppointmentsByPatientQuery, GetListResponse<GetAppointmentsByPatientResponse>>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;

            public GetAppointmentsByPatientQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetAppointmentsByPatientResponse>> Handle(GetAppointmentsByPatientQuery request, CancellationToken cancellationToken)
            {
                Expression<Func<Appointment, bool>> predicate = a =>
                    a.PatientId == request.PatientId;

                IPaginate<Appointment> appointments = await _appointmentRepository.GetListAsync(
                    predicate: predicate,
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                var response = _mapper.Map<GetListResponse<GetAppointmentsByPatientResponse>>(appointments);
                return response;
            }
        }
    }
}
