using Application.Repositories;
using AutoMapper;
using Core.Paging;
using Core.Requests;
using Core.Responses;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Queries.GetByDoctorAndDate
{
    public class GetAppointmentsByDoctorAndDateQuery : IRequest<GetListResponse<GetAppointmentsByDoctorAndDateResponse>>
    {
        public PageRequest PageRequest { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }

        public class GetAppointmentsByDoctorAndDateQueryHandler : IRequestHandler<GetAppointmentsByDoctorAndDateQuery, GetListResponse<GetAppointmentsByDoctorAndDateResponse>>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;

            public GetAppointmentsByDoctorAndDateQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetAppointmentsByDoctorAndDateResponse>> Handle(GetAppointmentsByDoctorAndDateQuery request, CancellationToken cancellationToken)
            {
                DateTime startOfDay = request.Date.Date;
                DateTime endOfDay = startOfDay.AddDays(1).AddTicks(-1);

                Expression<Func<Appointment, bool>> predicate = a =>
                    a.DoctorAvailability.DoctorId == request.DoctorId &&
                    a.StartTime >= startOfDay &&
                    a.StartTime <= endOfDay;

                IPaginate<Appointment> appointments = await _appointmentRepository.GetListAsync(
                    predicate: predicate,
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    include: i => i.Include(a => a.DoctorAvailability)
                );

                var response = _mapper.Map<GetListResponse<GetAppointmentsByDoctorAndDateResponse>>(appointments);
                return response;
            }
        }
    }
}
