using Application.Repositories;
using AutoMapper;
using Core.Paging;
using Core.Requests;
using Core.Responses;
using Domain.Entities;
using MediatR;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Doctors.Queries.GetByDepartment
{
    public class GetDoctorsByDepartmentQuery : IRequest<GetListResponse<GetDoctorsByDepartmentResponse>>
    {
        public PageRequest PageRequest { get; set; }
        public int DepartmentId { get; set; } // Departman ID'si

        public class GetDoctorsByDepartmentQueryHandler : IRequestHandler<GetDoctorsByDepartmentQuery, GetListResponse<GetDoctorsByDepartmentResponse>>
        {
            private readonly IDoctorRepository _doctorRepository;
            private readonly IMapper _mapper;

            public GetDoctorsByDepartmentQueryHandler(IDoctorRepository doctorRepository, IMapper mapper)
            {
                _doctorRepository = doctorRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetDoctorsByDepartmentResponse>> Handle(GetDoctorsByDepartmentQuery request, CancellationToken cancellationToken)
            {
                Expression<Func<Doctor, bool>> predicate = d => d.DepartmentId == request.DepartmentId;

                IPaginate<Doctor> doctors = await _doctorRepository.GetListAsync(
                    predicate: predicate,
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                );

                var response = _mapper.Map<GetListResponse<GetDoctorsByDepartmentResponse>>(doctors);
                return response;
            }
        }
    }
}
