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

namespace Application.Features.Appointments.Queries.GetByDoctorAndWeek
{
    public class GetAppointmentsByDoctorAndWeekQuery : IRequest<GetListResponse<GetAppointmentsByDoctorAndWeekResponse>>
    {
        public PageRequest PageRequest { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }

        public class GetAppointmentsByDoctorAndWeekQueryHandler : IRequestHandler<GetAppointmentsByDoctorAndWeekQuery, GetListResponse<GetAppointmentsByDoctorAndWeekResponse>>
        {
            private readonly IAppointmentRepository _appointmentRepository;
            private readonly IMapper _mapper;

            public GetAppointmentsByDoctorAndWeekQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
            {
                _appointmentRepository = appointmentRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetAppointmentsByDoctorAndWeekResponse>> Handle(GetAppointmentsByDoctorAndWeekQuery request, CancellationToken cancellationToken)
            {
                
                DateTime startOfWeek = request.Date; 
                DateTime endOfWeek = startOfWeek.AddDays(DayOfWeek.Saturday - startOfWeek.DayOfWeek); 

                Expression<Func<Appointment, bool>> predicate = a =>
                    a.DoctorAvailability.DoctorId == request.DoctorId &&
                    a.StartTime >= startOfWeek &&
                    a.StartTime <= endOfWeek;

                IPaginate<Appointment> appointments = await _appointmentRepository.GetListAsync(
                    predicate: predicate,
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    include: i => i.Include(a => a.DoctorAvailability) 
                );

                var response = _mapper.Map<GetListResponse<GetAppointmentsByDoctorAndWeekResponse>>(appointments);
                return response;
            }
        }
    }
}
